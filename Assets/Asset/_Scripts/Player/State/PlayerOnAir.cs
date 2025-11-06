using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAir : IState
{
    PlayerController player;
    public PlayerOnAir(PlayerController _player)
    {
        player = _player;
    }
    public void Enter()
    {
        player.ani.Play("Falling");
    }

    public void LogicUpdate()
    {
        player.Movement.Move();
        if(player.Movement.IsOnObstacle) { player.StateMC.ChangeState<PlayerIdle>(); return; }
        if(player.Movement.IsOnGround) { player.StateMC.ChangeState<PlayerMove>(); return; }
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {
       
    }
}
