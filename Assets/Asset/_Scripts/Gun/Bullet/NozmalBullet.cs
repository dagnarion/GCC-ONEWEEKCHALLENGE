using UnityEngine;
public class NozmalBullet : BulletAbstract
{
    protected override void Fly()
    {
        transform.Translate(Vector2.right * Data.Speed * Time.deltaTime);
    }
}
