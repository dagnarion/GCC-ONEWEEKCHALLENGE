using System.Collections.Generic;
using UnityEngine;

public class NozmalSpawn : SpawnAbstract
{
    [SerializeField] List<GameObject> obstacle;
    [SerializeField] List<GameObject> enemy;
    float delayTimer;
    int randomNumber;
    void Start()
    {
        delayTimer = delayTime;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= delayTimer) return;
        timer = 0;
        delayTimer = Random.Range(delayTime - 1, delayTime);
        Randomize();
    }

    void Randomize()
    {
        float randomValue = Random.value;
        if (randomValue < 0.8f)
        {
            Spawn(obstacle[Random.Range(0, obstacle.Count)]);
        }
        else
        {
            Spawn(enemy[Random.Range(0, enemy.Count)]);
        }
    }
}
