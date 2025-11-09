using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [field: SerializeField] public float CurrentSpeed { get; private set; }
    public float CurrentDistance { get; private set; }
    float DelayBetweenLevel = 1f;
    float Timer;
    float DistanceTimer;
    public void ResetLevel()
    {
        Timer = 0;
        CurrentSpeed = 0;
        CurrentDistance = 0;
    }
    void Update()
    {
        DistanceTimer += Time.deltaTime;
        if (DistanceTimer <= 0.5f) return;
        DistanceTimer = 0;
        CurrentDistance++;
    }

    void FixedUpdate()
    {
        Timer += Time.fixedDeltaTime;
        if (Timer <= DelayBetweenLevel) return;
        Timer -= DelayBetweenLevel;
        CurrentSpeed += 0.05f;
    }
}
