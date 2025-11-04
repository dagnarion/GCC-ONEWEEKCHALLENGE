using UnityEngine;
public class NozmalBullet : BulletAbstract
{
    void Update()
    {
        Fly();
        if (!IsOnCamera()) this.gameObject.SetActive(false);
    }
    protected override void Fly()
    {
        transform.Translate(Vector2.right * Data.Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy")) this.gameObject.SetActive(false);
    }
}
