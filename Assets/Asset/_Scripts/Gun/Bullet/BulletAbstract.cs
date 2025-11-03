using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    [SerializeField] protected BulletDataSO Data;
    protected Camera cam;

    protected void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Fly();
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
        {
            gameObject.SetActive(false);
        }
    }

    protected abstract void Fly();
}
