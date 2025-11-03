using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public StateMachine StateMC { get; private set; }

    void Awake()
    {
        StateMC.AddState(new PlayerOnAir(this));
        StateMC.AddState(new PlayerOnGround(this));
    }

    void Start()
    {
        StateMC.ChangeState<PlayerOnGround>();
    }

}
