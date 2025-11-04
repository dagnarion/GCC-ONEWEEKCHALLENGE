using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigi;
    Camera Cam;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        Cam = Camera.main;
    }
    void Update()
    {
        rigi.velocity = -Vector2.right * speed;
        if(Mathf.Abs(transform.position.x - Cam.transform.position.x) >= 20f)
        {
            // để tạm, sau thay bằng disable object
            transform.position = new Vector3(Cam.transform.position.x, transform.position.y, transform.position.z);
        }
    }
    public Vector2 GetVelocity => rigi.velocity;
}
