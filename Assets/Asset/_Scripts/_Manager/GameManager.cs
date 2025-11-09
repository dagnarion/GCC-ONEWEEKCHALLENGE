using System;
using UnityEngine;

public class GameManager : SingletonDonDestroyOnLoad<GameManager>
{
    public GameState currentGameState;
    public static event Action<GameState> OnGameStateChange;
    void Start()
    {
        UpdateGameState(GameState.OnMenu);
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
            case GameState.OnMenu:
                GameMenu();
                break;
        }
        OnGameStateChange?.Invoke(state);
    }
    // có vẻ hơi thừa
    void OnPlay()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayMusic(MusicSoundType.InGame, 1);
    }

    void OnPause()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic();
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic();
    }
    void GameMenu()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlayMusic(MusicSoundType.Menu,0.75f);
    }
}
public enum GameState
{
    OnPlay = 0, OnPause = 1,OnShop = 2,GameOver = 3,OnMenu = 4
}