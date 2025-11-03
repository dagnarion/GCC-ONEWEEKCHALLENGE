using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : IState
{
    PlayerController player;
    float jumpBufferTimer;
    public PlayerOnGround(PlayerController _player)
    {
        player = _player;
    }

    public void Enter()
    {
        jumpBufferTimer = 0;
    }

    public void LogicUpdate()
    {
        player.Movement.Move();
        if (InputManager.Instance.IsJumpPressed) { jumpBufferTimer = 0.5f; }
        jumpBufferTimer -= Time.deltaTime;
        if(jumpBufferTimer>=0)
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
