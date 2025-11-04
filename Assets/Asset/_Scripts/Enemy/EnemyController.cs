using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!IsOnCamera()) { this.gameObject.SetActive(false); return; }
    }

    bool IsOnCamera()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
        {
            return false;
        }
        return true;
    }
}
// quản lý trạng thái của enemy, quản lý việc khởi tạo cũng như hủy enemy