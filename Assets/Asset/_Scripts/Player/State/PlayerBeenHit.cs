using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeenHit : IState
{
    PlayerController player;
    public PlayerBeenHit(PlayerController _player)
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
