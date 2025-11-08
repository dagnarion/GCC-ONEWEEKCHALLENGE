using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState currentGameState;
    public static event Action<GameState> OnGameStateChange;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(Instance);
    }
    void Start()
    {
        UpdateGameState(GameState.OnPlay);
    }

    public void UpdateGameState(GameState state)
    {
        currentGameState = state;
        switch (currentGameState)
        {
            case GameState.OnPlay:
                OnPlay();
                break;
            case GameState.OnPause:
                OnPause();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.OnShop:
                OnShop();
                break;
        }
        OnGameStateChange?.Invoke(state);
    }
    // có vẻ hơi thừa
    void OnPlay()
    {
        Time.timeScale = 1f;
    }

    void OnPause()
    {
        Time.timeScale = 0f;
    }
    void GameOver()
    {
        Time.timeScale = 0f;
    }
    void OnShop()
    {
        Time.timeScale = 0f;
    }
}
public enum GameState
{
    OnPlay = 0, OnPause = 1,OnShop = 2,GameOver = 3,Loading = 4
}