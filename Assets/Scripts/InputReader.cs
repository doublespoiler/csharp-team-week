using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{

  private Controls controls;
  public event Action JumpEvent;
  public event Action DodgeEvent;
  public event Action SprintEvent;
  public Vector2 MovementValue { get; private set;}


  void Start()
  {
    controls = new Controls();
    controls.Player.SetCallbacks(this);
    controls.Player.Enable();
  }

  private void OnDestroy() 
  {
    controls.Player.Disable(); 
  }

  public void OnJump(InputAction.CallbackContext context)
  {
    if (!context.performed) { return; }
    JumpEvent?.Invoke();
  }

  public void OnDodge(InputAction.CallbackContext context)
  {
    if(!context.performed) { return; }
    DodgeEvent?.Invoke();
  }

  public void OnMove(InputAction.CallbackContext context)
  {
    MovementValue = context.ReadValue<Vector2>();
  }

  public void OnLook(InputAction.CallbackContext context)
  {
    
  }

  public void OnSprint(InputAction.CallbackContext context)
  {
    MovementValue = context.ReadValue<Vector2>();
    SprintEvent?.Invoke();
  }

}
