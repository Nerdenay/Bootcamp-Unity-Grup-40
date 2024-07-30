using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;

    public Vector2 MovementInput;
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


}
