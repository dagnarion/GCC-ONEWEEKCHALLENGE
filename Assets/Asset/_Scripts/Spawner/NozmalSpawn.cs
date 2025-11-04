using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozmalSpawn : SpawnAbstract
{
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= delayTime) return;
        timer -= delayTime;
        Spawn();
    }
}
