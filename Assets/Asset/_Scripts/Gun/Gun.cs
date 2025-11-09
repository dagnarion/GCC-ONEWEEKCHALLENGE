using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] List<GameObject> bullets;
    GameObject currentBullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform holder;
    [SerializeField] float DelayTime;
    [SerializeField] int numberOfBulletPath = 1;
    [SerializeField] float BulletAngle;
    float timer;
    void Awake()
    {
        mainCam = Camera.main;
    }
    public void Init(int _currentBullet = 0)
    {
        numberOfBulletPath = 1;
        currentBullet = bullets[_currentBullet];
    }

    void Update()
    {
        ChangeDirection(mainCam.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButton(0) && timer >= DelayTime)
        {
            AudioManager.Instance.PlaySound(SfxSoundType.Gun,0.75f);
            Shoot();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void ChangeDirection(Vector3 mousePos)
    {
        Vector2 dir = (mousePos - this.transform.position).normalized;
        float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

    public void ChangeBullet(BulletDataSO bullet)
    {
        if (currentBullet == bullets[(int)bullet.type]) { numberOfBulletPath = Mathf.Clamp(numberOfBulletPath + 1, 1, 5); return; }
        currentBullet = bullets[(int)bullet.type];
    }

    void Shoot()
    {
        Vector2 originPosition = firePoint.position;
        Quaternion rotation = firePoint.rotation;
        Vector3 euler = rotation.eulerAngles;
        if (numberOfBulletPath % 2 != 0) Shoot(originPosition, rotation);
        for (int i = 1; i <= numberOfBulletPath / 2; i++)
        {
            rotation = Quaternion.Euler(0, 0, euler.z + BulletAngle * i);
            Shoot(originPosition, rotation);
            rotation = Quaternion.Euler(0, 0, euler.z - BulletAngle * i);
            Shoot(originPosition, rotation);
        }
    }

    void Shoot(Vector2 position, Quaternion rotation)
    {
        GameObject obj = ObjectPooling.Instance.Pool(currentBullet, position, rotation, holder);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
    }
}
