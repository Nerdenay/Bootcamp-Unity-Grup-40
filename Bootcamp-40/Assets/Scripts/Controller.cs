using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private float _dashSpeed = 10;   //  Dash s�ras�nda kullan�lacak h�z.
    [SerializeField] private float _dashDuration = 5.0f; //  Dash time
    [SerializeField] private float _dashCooldown = 5.0f;

    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 _input;

    private bool _isDashing = false;   // dash hal�nda mi bakacak
    private float _dashTimer = 0;  // dash time'� kontrol et
    private float _cooldownTimer = 0;  // yeniden dash yapabilme suresi
    private bool isGrounded;

    private void Update()
    {
        GatherInput();
        Look();

        // Dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && _cooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }

        // Update cooldown timer
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
        }
        GroundCheck();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float currentSpeed = _isDashing ? _dashSpeed : _speed;
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * currentSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        _isDashing = true;
        _dashTimer = _dashDuration;
        _cooldownTimer = _dashCooldown;

        while (_dashTimer > 0)
        {
            _dashTimer -= Time.deltaTime;
            yield return null;
        }
        _isDashing = false;
    }
    private void GroundCheck()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask);

        if (!isGrounded)
        {
            _rb.velocity += Vector3.down * 9.81f * Time.deltaTime;
        }
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}





