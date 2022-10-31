using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
  private State currentState;

  // Update is called once per frame
  private void Update()
  {
    currentState?.Tick(Time.deltaTime); //if current state is not null, do currentState.Tick() null conditional operator
  }

  public void SwitchState(State newState)
  {
    currentState?.Exit();
    currentState = newState;
    currentState?.Enter();
  }
}
