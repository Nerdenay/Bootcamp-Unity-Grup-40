using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private Camera playerCamera;
    private float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; // Fare imlecini ekranýn ortasýnda kilitle
        Cursor.visible = false; // Fare imlecini görünmez yap
    }

    void Update()
    {
        // Oyuncunun hareketi
        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * speed;
        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection.y = moveDirectionY;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        // Kamera hareketi
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}