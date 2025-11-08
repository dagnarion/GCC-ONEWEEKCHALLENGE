using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : IState
{
    PlayerController player;
    public PlayerJump(PlayerController _player)
    {
        player = _player;
    }
    public void Enter()
    {
        player.Movement.Jump();
        player.ani.Play("Jump");
    }

    public void LogicUpdate()
    {
        player.Movement.Move(); 
        if (player.Movement.IsOnObstacle)
        {
            player.StateMC.ChangeState<PlayerIdle>();
            return;
        }
        if (player.Movement.IsOnGround)
        {
            player.StateMC.ChangeState<PlayerMove>();
            return;
        }
        if (player.Movement.IsJumpDone())
        {
            player.StateMC.ChangeState<PlayerOnAir>();
            return;
        }
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {

    }
}
