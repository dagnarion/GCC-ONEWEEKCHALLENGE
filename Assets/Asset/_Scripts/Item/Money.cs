using UnityEngine;

public class Money : MonoBehaviour
{
    Camera cam;
    [SerializeField] MoneyDataSO moneyData;
    [SerializeField] float Speed;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if(!IsOnCamera())
        {
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ICollector>(out ICollector collector))
        {
            collector.Loot(moneyData);
            AudioManager.Instance.PlaySound(SfxSoundType.Coin,0.5f);
            this.gameObject.SetActive(false);
        }
    }
     protected virtual bool IsOnCamera()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
        {
            return false;
        }
        return true;
    }
}
