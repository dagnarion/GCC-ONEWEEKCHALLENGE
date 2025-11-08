using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IState
{
    PlayerController player;
    public PlayerIdle(PlayerController _player)
    {
        player = _player;
    }

    public void Enter()
    {
        player.Movement.ResetNumberOfJump();
        player.ani.Play("Idle");
    }

    public void LogicUpdate()
    {
        player.Movement.Move();
        if (InputManager.Instance.PlayerMove != 0)
        {
            player.StateMC.ChangeState<PlayerMove>();
            return;
        }
        if (InputManager.Instance.IsJumpPressed)
        {
            player.StateMC.ChangeState<PlayerJump>();
            return;
        }
        if(!player.Movement.IsOnGround)
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
