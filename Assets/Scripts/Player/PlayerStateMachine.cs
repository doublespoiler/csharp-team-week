using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField]
    public InputReader InputReader { get; private set; }
    [field: SerializeField]
    public CharacterController CharacterController { get; private set; }
    [field: SerializeField]
    public float FreeLookMoveSpeed { get; private set; }
    [field: SerializeField]
    public Animator Animator { get; private set;}
    [field: SerializeField]
    public float BackPedalMoveSpeed { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
      SwitchState(new PlayerTestState(this));
    }

}
