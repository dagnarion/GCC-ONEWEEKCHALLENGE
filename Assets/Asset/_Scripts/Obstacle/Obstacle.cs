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
        rigi.velocity = -Vector2.right * (speed + LevelManager.Instance.CurrentSpeed);
        if(Mathf.Abs(transform.position.x - Cam.transform.position.x) >= 20f)
        {
            this.gameObject.SetActive(false);
        }
    }
    public Vector2 GetVelocity => rigi.velocity;
}
