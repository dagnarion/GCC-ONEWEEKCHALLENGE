using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IAttackable
{
    [SerializeField] PlayerDataSO Data;
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public StateMachine StateMC { get; private set; }
    [SerializeField] HealthSystem health;
    [field: SerializeField] public Animator ani { get; private set; }

    void Awake()
    {
        StateMC.AddState(new PlayerOnAir(this));
        StateMC.AddState(new PlayerMove(this));
        StateMC.AddState(new PlayerBeenHit(this));
        StateMC.AddState(new PlayerDead(this));
        StateMC.AddState(new PlayerJump(this));
        StateMC.AddState(new PlayerIdle(this));
        // Need Hit State :>
    }
    void OnEnable()
    {
        health.Init(Data.BaseHp);
        StateMC.ChangeState<PlayerMove>();
    }

    public void OnHit(int damage)
    {
        health.Detuc(damage);
        if (!health.IsAlive()) { StateMC.ChangeState<PlayerDead>(); return; }
        StateMC.ChangeState<PlayerBeenHit>();
    }
}

