using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IAttackable
{
    Camera cam;
    [SerializeField] GameObject particle;
    [SerializeField] HealthSystem health;
    [SerializeField] EnemyDataSO Data;
    [SerializeField] EnemyMovement movement;
    [SerializeField] Collider2D coll;
    [SerializeField] Animator ani;
    [SerializeField] EnemySpawnItem spawnItem;
    void Awake()
    {
        cam = Camera.main;
    }

    void OnEnable()
    {
        health.Init(Data.BaseHp);
        health.Reborn();
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

    public void OnHit(int damage)
    {
        health.Detuc(damage);
        if (!health.IsAlive())
        {
            SpawnParticle();
            spawnItem.Spawn();
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            ani.SetTrigger("Hit");
        }
    }

    void SpawnParticle()
    {
        GameObject obj = ObjectPooling.Instance.Pool(particle, transform.position, Quaternion.identity, null);
        obj.transform.position = this.transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if(collision.TryGetComponent<IAttackable>(out IAttackable attackable))
        {
            attackable.OnHit(Data.Damage);
            return;
        }
    }
}
// quản lý trạng thái của enemy, quản lý việc khởi tạo cũng như hủy enemy