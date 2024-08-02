using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    InputManager inputmanager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRB;
    public float gravity = -9.81f;  // Yerçekimi kuvveti negatif olmalý

    [SerializeField] public float movementSpeed = 7.0f;
    [SerializeField] public float rotationSpeed = 15;

    // Ground check deðiþkenleri
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        inputmanager = GetComponent<InputManager>();
        cameraObject = Camera.main.transform;
    }

    private void Start()
    {
        // Baþlangýçta yerçekiminin doðru uygulanmasý için Rigidbody bileþenini sýfýrlayýn
        playerRB.velocity = Vector3.zero;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log("Is Grounded: " + isGrounded);
        Debug.Log("Velocity Y: " + playerRB.velocity.y);
        if (isGrounded && playerRB.velocity.y < 0)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);
        }
    }

    public void HandleAllMovements()
    {
        HandleMovement();
        HandleDirection();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputmanager.verticalInput + cameraObject.right * inputmanager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        Vector3 movementVelocity = moveDirection * movementSpeed;
        movementVelocity.y = playerRB.velocity.y; // Mevcut y hýzýný koru
        playerRB.velocity = movementVelocity;

        if (!isGrounded)
        {
            playerRB.AddForce(Vector3.up * gravity * playerRB.mass);
        }
    }

    private void HandleDirection()
    {
        Vector3 targetDirection = cameraObject.forward * inputmanager.verticalInput + cameraObject.right * inputmanager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}

