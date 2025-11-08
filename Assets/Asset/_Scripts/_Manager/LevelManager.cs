using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [field:SerializeField] public float CurrentSpeed { get; private set; }
    float DelayBetweenLevel = 1f;
    float Timer;
    public void ResetLevel()
    {
        Timer = 0;
        CurrentSpeed = 0;
        GameManager.Instance.UpdateGameState(GameState.OnPlay);
        SceneManager.LoadScene(1);
    }
    void FixedUpdate()
    {
        Timer += Time.fixedDeltaTime;
        if (Timer <= DelayBetweenLevel) return;
        Timer -= DelayBetweenLevel;
        CurrentSpeed += 0.05f;
    }

}
