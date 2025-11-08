using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnItem : MonoBehaviour
{
    [SerializeField] List<GameObject> money;
    [SerializeField] List<GameObject> bullet;
    public void Spawn()
    {
        int rand = Random.Range(0, 100);
        if (rand < 80)
        {
            int randomNumber = Random.Range(0, money.Count - 1);
            ObjectSpawn(money[randomNumber]);
        }
        else
        {
            int randomNumber = Random.Range(0, bullet.Count);
            ObjectSpawn(bullet[randomNumber]);
        }
    }
    
    void ObjectSpawn(GameObject obj)
    {
        GameObject tmp = ObjectPooling.Instance.Pool(obj, this.transform.position, Quaternion.identity, null);
        tmp.transform.position = this.transform.position;
        tmp.SetActive(true);
    }
}
