using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAir : IState
{
    PlayerController player;
    int numberOfJumpHadUsed;
    public PlayerOnAir(PlayerController _player)
    {
        player = _player;
    }
    public void Enter()
    {
        player.Movement.Jump();
        numberOfJumpHadUsed = 1;
    }

    public void LogicUpdate()
    {
        if (player.Movement.IsOnGround) { player.StateMC.ChangeState<PlayerOnGround>(); return; }
        player.Movement.Move();
        if (InputManager.Instance.IsJumpPressed && numberOfJumpHadUsed<1) { numberOfJumpHadUsed++; player.Movement.Jump(); }
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {
       
    }
}
