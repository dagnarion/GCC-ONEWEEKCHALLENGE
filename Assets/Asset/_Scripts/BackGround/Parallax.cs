using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float speedDifference = 0.2f;
    [SerializeField] float Speed; // để tạm, speed sẽ do levelManager xử lý
    Vector2 originPosition;
    void Awake()
    {
        originPosition = Camera.main.transform.position;
    }
    void Update()
    {
        BackgroundMove();
    }
    void BackgroundMove()
    {
        transform.Translate(Vector2.left * Speed * speedDifference * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - originPosition.x) >= 25.04348f)
        {
            transform.position = new Vector3(originPosition.x, transform.position.y);
        }
    }

}
