using UnityEngine;

public class SineBullet : BulletAbstract
{
    Vector3 startPos;
    float amplitude = 1f;
    float frequency = 2f;
    Vector3 normal;
    float timer = 0f;
    float phase;


    void OnEnable()
    {
        startPos = transform.position;
        normal = Vector3.Cross(transform.right, Vector3.forward).normalized;
        timer = 0f;
        phase = Random.Range(0f, 2f * Mathf.PI);
        amplitude = Random.Range(0f, 1f);
    }

    void Update()
    {
        Fly();
        if (!IsOnCamera()) this.gameObject.SetActive(false);
    }

    protected override void Fly()
    {
        timer += Time.deltaTime;
        float sineOffset = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * timer + phase);
        transform.position = startPos + transform.right * Data.Speed * timer + normal * sineOffset;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Enemy")) this.gameObject.SetActive(false);
    }
}
