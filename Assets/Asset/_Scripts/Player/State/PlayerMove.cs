using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : IState
{
    PlayerController player;
    public PlayerMove(PlayerController _player)
    {
        player = _player;
    }

    public void Enter()
    {
       player.ani.Play("Run");
    }

    public void LogicUpdate()
    {
        player.Movement.Move();
        if (!player.Movement.IsOnGround) { player.StateMC.ChangeState<PlayerOnAir>(); return; }
        if(player.Movement.IsOnObstacle && InputManager.Instance.PlayerMove == 0) { player.StateMC.ChangeState<PlayerIdle>(); return; }
        if(InputManager.Instance.IsJumpPressed) { player.StateMC.ChangeState<PlayerJump>(); return; }
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {
        
    }
}
