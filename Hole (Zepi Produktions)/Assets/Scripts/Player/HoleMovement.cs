using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;

public class HoleMovement : MonoBehaviour
{
    // Serialize Fields
    [Header("Data")]
    [SerializeField] private Vector2 moveLimits;
    [SerializeField] [Range(1, 10)] private float movementSpeed = 5;
    
    [Header("Components")]
    [SerializeField] private Transform holeCenter;

    // Vectors
    Vector3 movementDirection, targetPos;

    // Components
    private InputMaster inputMaster;

    // Is called when script instancs is loaded
    private void Awake()
    {
        // Set Components
        inputMaster = new InputMaster();

        // Get controls from the inputMaster
        inputMaster.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    // Is called every physik frame
    private void FixedUpdate()
    {
        if (!Game.isGameover)
        {
            targetPos = new Vector3
            (
                Mathf.Clamp(movementDirection.x, -moveLimits.x, moveLimits.x),
                movementDirection.y,
                Mathf.Clamp(movementDirection.z, -moveLimits.y, moveLimits.y)
            );

            holeCenter.position = targetPos;
        }
    }

    // Is called when the input action is peformed
    private void Move(Vector2 direction)
    {
        movementDirection = Vector3.Lerp(holeCenter.position, holeCenter.position + new Vector3(direction.x, 0, direction.y), movementSpeed * Time.deltaTime);
    }

    // Is called when this GameObject is enabled
    private void OnEnable()
    {
        inputMaster.Enable();
    }

    // Is called when this GameObjekt is disabled
    private void OnDisable()
    {
        inputMaster.Disable();
    }
}
