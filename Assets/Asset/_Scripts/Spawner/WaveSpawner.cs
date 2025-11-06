using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : SpawnAbstract
{
    int numberEnemyOnWave = 5;
    float delayBetweenEnemy = 0.75f;
    [SerializeField] int numberOfEnemy = 1;
    [SerializeField] protected GameObject prefab;
    Coroutine spawner;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= delayTime) return;
        timer = 0;
        numberOfEnemy = Random.Range(1, numberEnemyOnWave);
        if (spawner != null) StopCoroutine(spawner);
        spawner = StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        for(int i = 1;i<=numberEnemyOnWave;i++)
        {
            yield return new WaitForSeconds(delayBetweenEnemy);
            Spawn(prefab);
        }
    }

}
