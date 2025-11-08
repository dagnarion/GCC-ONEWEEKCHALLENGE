using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float PlayerMove { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsJumpReleased { get; private set; }
    public bool IsPauseButtonPressed { get; private set; }
    public bool IsShopButtonPressed { get; private set; }

    void OnEnable()
    {
        GameManager.OnGameStateChange += SwitchInput;
    }

    void OnDisable()
    {
        GameManager.OnGameStateChange -= SwitchInput;
    }
    void Update()
    {
        SwitchInput(GameManager.Instance.currentGameState);
    }

    void SwitchInput(GameState state)
    {
        switch (state)
        {
            case GameState.OnPlay:
                OnPlayHandle();
                break;
            case GameState.OnPause:
                OnPauseHandle();
                break;
        }
    }

    void OnPlayHandle()
    {
        PlayerMove = Input.GetAxisRaw("Horizontal");
        IsJumpPressed = Input.GetKeyDown(KeyCode.Space);
        IsJumpReleased = Input.GetKeyUp(KeyCode.Space);
        IsPauseButtonPressed = Input.GetKeyDown(KeyCode.Escape);
        IsShopButtonPressed = Input.GetKeyDown(KeyCode.Tab);
    }

    void OnPauseHandle()
    {
        IsPauseButtonPressed = Input.GetKeyDown(KeyCode.Escape);
        IsShopButtonPressed = Input.GetKeyDown(KeyCode.Tab);
    }

}
