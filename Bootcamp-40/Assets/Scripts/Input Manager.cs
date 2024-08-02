using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;
    Animatormanager animatormanager;


    public Vector2 MovementInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animatormanager = GetComponent<Animatormanager>();
    }



    private void OnEnable()
    {

        if (playerControls == null)
        {

            playerControls = new PlayerControls();

            playerControls.PlayerMove.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();

    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {

        HandleMovementInput();
        // HandleJumpInput 
        // HAndleActionInput vb gelir

    }

    private void HandleMovementInput()
    {

        verticalInput = MovementInput.y;
        horizontalInput = MovementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatormanager.UpdateAnimatorValues(0, moveAmount); 
    }


}
