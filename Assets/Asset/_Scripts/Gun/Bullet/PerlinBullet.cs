using UnityEngine;

public class PerlinBullet : BulletAbstract
{
    Vector3 startPos;
    Vector3 direction;
    Vector3 normal;
    float timer;
    float seed;
    public float amplitude = 3f;
    public float noiseFreq = 3f;

    void OnEnable()
    {
        startPos = transform.position;
        direction = transform.right.normalized;
        normal = Vector3.Cross(direction, Vector3.forward).normalized;
        timer = 0f;
        seed = Random.value * 100f;
        amplitude = Random.Range(1f, 2f);
        noiseFreq = Random.Range(1f, 2f);

    }
     void Update()
    {
        Fly();
        if (!IsOnCamera()) this.gameObject.SetActive(false);
    }

    protected override void Fly()
    {
        timer += Time.deltaTime;
        float noise = (Mathf.PerlinNoise(seed, timer * noiseFreq) - 0.5f) * 2f;
        transform.position = startPos + direction * Data.Speed * timer + normal * (amplitude * noise);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent<IAttackable>(out IAttackable attackable))
            {
                attackable.OnHit(Data.Damage);
            }
            this.gameObject.SetActive(false);
        }
    }
    void OnDisable()
    {
        trail.Clear();
    }
}

