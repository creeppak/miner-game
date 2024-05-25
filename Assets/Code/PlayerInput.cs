using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputActionAsset inputAsset;
    public Player player;
    
    private InputAction moveForwardAction;
    private InputAction moveBackwardAction;
    private InputAction rotateLeftAction;
    private InputAction rotateRightAction;
    private InputAction hitAction;

    private void Awake()
    {
        moveForwardAction = inputAsset.FindActionMap("player-movement").FindAction("move-forward");
        moveBackwardAction = inputAsset.FindActionMap("player-movement").FindAction("move-backward");
        rotateLeftAction = inputAsset.FindActionMap("player-movement").FindAction("rotate-left");
        rotateRightAction = inputAsset.FindActionMap("player-movement").FindAction("rotate-right");
        hitAction = inputAsset.FindActionMap("player-actions").FindAction("hit");

        // moveForwardAction.performed += _ => player.Move(+1);
        // moveBackwardAction.performed += _ => player.Move(-1);
        // rotateLeftAction.performed += _ => player.Rotate(-1);
        // rotateRightAction.performed += _ => player.Rotate(+1);
    }

    private void OnEnable()
    {
        moveForwardAction.Enable();
        moveBackwardAction.Enable();
        rotateLeftAction.Enable();
        rotateRightAction.Enable();
        hitAction.Enable();
    }

    private void OnDisable()
    {
        moveForwardAction.Disable();
        moveBackwardAction.Disable();
        rotateLeftAction.Disable();
        rotateRightAction.Disable();
        hitAction.Disable();
    }

    private void Update()
    {
        if (moveForwardAction.IsPressed()) player.Move(+1);
        if (moveBackwardAction.IsPressed()) player.Move(-1);
        if (rotateLeftAction.IsPressed()) player.Rotate(-1);
        if (rotateRightAction.IsPressed()) player.Rotate(+1);
        if (hitAction.IsPressed()) player.Hit();
    }
}