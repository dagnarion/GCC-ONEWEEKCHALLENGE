using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    [SerializeField] protected BulletDataSO Data;
    [SerializeField] protected TrailRenderer trail;
    protected Camera cam;

    protected void Awake()
    {
        cam = Camera.main;
    }

    protected virtual bool IsOnCamera()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
        {
            return false;
        }
        return true;
    }
    protected abstract void Fly();
}
