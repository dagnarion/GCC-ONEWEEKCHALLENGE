using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins;
using UnityEngine;

public abstract class SpawnAbstract : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected GameObject prefabs;
    [SerializeField] protected float delayTime;
    protected float timer;
    protected void OnEnable()
    {
        timer = delayTime;
    }
    protected void Spawn()
    {
        GameObject obj = ObjectPooling.Instance.Pool(prefabs, this.transform.position, Quaternion.identity, holder);
        obj.transform.position = this.transform.position;
        obj.SetActive(true);
    }


}
