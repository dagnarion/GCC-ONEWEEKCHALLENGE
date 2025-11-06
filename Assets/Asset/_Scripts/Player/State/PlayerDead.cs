using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : IState
{
    PlayerController player;
    public PlayerDead(PlayerController _player)
    {
        player = _player;
    }
    public void Enter()
    {

    }

    public void LogicUpdate()
    {
        
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {
       
    }
}
