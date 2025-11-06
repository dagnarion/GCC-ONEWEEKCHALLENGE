using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] List<GameObject> bullets; // demo đạn
    [SerializeField] GameObject bullet;
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

    void Update()
    {
        ChangeDirection(mainCam.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButton(0) && timer >= DelayTime)
        {
            Shoot();
            timer = 0;
        }
        timer += Time.deltaTime;
        SwitchBullet();
    }

    void SwitchBullet()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) { bullet = bullets[0]; }
        if(Input.GetKeyDown(KeyCode.Alpha2)) { bullet = bullets[1]; }
        if(Input.GetKeyDown(KeyCode.Alpha3)) { bullet = bullets[2]; }
    }
    
    void ChangeDirection(Vector3 mousePos)
    {
        Vector2 dir = (mousePos - this.transform.position).normalized;
        float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

    void Shoot()
    {
        Vector2 originPosition = firePoint.position;
        Quaternion rotation = firePoint.rotation;
        Vector3 euler = rotation.eulerAngles;
        if (numberOfBulletPath % 2 != 0) Shoot(originPosition, rotation);
        for(int i = 1;i<=numberOfBulletPath/2;i++)
        {
            rotation = Quaternion.Euler(0, 0,euler.z+BulletAngle * i);
            Shoot(originPosition, rotation);
            rotation = Quaternion.Euler(0, 0, euler.z-BulletAngle * i);
            Shoot(originPosition, rotation);
        }
    }

    void Shoot(Vector2 position,Quaternion rotation)
    {
        GameObject obj = ObjectPooling.Instance.Pool(bullet,position,rotation,holder);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
    }
}
