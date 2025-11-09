using UnityEngine;

public class PlayerController : MonoBehaviour, IAttackable, ICollector
{
    [SerializeField] PlayerDataSO Data;
    [SerializeField] GameObject particle;
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public StateMachine StateMC { get; private set; }
    [SerializeField] HealthSystem health;
    [SerializeField] Flash flash;
    [field: SerializeField] public Animator ani { get; private set; }
    [SerializeField] Gun gun;
    void Awake()
    {
        StateMC.AddState(new PlayerOnAir(this));
        StateMC.AddState(new PlayerMove(this));
        StateMC.AddState(new PlayerJump(this));
        StateMC.AddState(new PlayerIdle(this));
        // Need Hit State :>
    }
    void OnEnable()
    {
        health.Init(Data.BaseHp);
        health.Reborn();
        gun.Init();
        StateMC.ChangeState<PlayerMove>();
    }

    public void OnHit(int damage)
    {
        health.Detuc(damage);
        if (!health.IsAlive())
        {
            SpawnParticle();
            GameManager.Instance.UpdateGameState(GameState.GameOver);
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasGameOver>();
            gameObject.SetActive(false);
            return;
        }
        flash.Flashed();
    }

    void SpawnParticle()
    {
        GameObject part = ObjectPooling.Instance.Pool(particle, this.transform.position, Quaternion.identity, null);
        part.transform.position = this.transform.position;
        part.transform.rotation = Quaternion.identity;
        part.SetActive(true);
        return;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Loss"))
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.UpdateGameState(GameState.GameOver);
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasGameOver>();
        }
    }

    public void Loot(ItemData items)
    {
        if (items == null) return;
        switch(items)
        {
            case BulletDataSO bullet:
                gun.ChangeBullet(bullet);
                break;
            case MoneyDataSO money:
                EconomyManager.Instance.IncreaseMoney(money.amount);
                break;
            
        }
    }
}

