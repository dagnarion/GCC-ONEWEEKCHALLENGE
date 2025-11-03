using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState currentGameState;

    void Start()
    {
        currentGameState = GameState.OnPlay;
    }

}
public enum GameState
{
    OnPlay, OnPause
}