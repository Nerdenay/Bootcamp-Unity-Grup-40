using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;

    PlayerLocation playerLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocation>();

    }

    private void Update()
    {

        inputManager.HandleAllInputs();

    }

    private void FixedUpdate()
    {

        playerLocomotion.HandleAllMovements();

    }

}
