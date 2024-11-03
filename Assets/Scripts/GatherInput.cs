using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.PlayerNormal.Jump.performed += Jump;
        myControls.PlayerNormal.Jump.canceled += JumpStop;

        myControls.PlayerNormal.Attack.performed += Attack;
        myControls.PlayerNormal.Attack.canceled += AttackStop;

        myControls.Enable();
    }

    private void Jump(InputAction.CallbackContext value)
    { 
        tryToJump = value.ReadValueAsButton();
    }

    private void JumpStop(InputAction.CallbackContext value) 
    { 
        tryToJump = value.ReadValueAsButton();
    }

    private void Attack(InputAction.CallbackContext value)
    { 
        tryToAttack = value.ReadValueAsButton();
    }

    private void AttackStop(InputAction.CallbackContext value)
    { 
        tryToAttack = value.ReadValueAsButton();
    }

    void Update()
    {
        valueX = myControls.PlayerNormal.MoveHorizontal.ReadValue<float>();
    }

    private void OnDisable()
    {
        myControls.PlayerNormal.Jump.performed -= Jump;
        myControls.PlayerNormal.Jump.canceled -= JumpStop;

        myControls.PlayerNormal.Attack.performed -= Attack;
        myControls.PlayerNormal.Attack.canceled -= AttackStop;

        myControls.Disable();
    }
}
