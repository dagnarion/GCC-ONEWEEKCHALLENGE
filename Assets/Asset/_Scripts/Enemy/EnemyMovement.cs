using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField] public EnemyDataSO enemyData;
    public Rigidbody2D rigi { get; private set; }
    IBehaviour behaviour;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        switch (enemyData.EnemyType)
        {
            case TypeOfEnemy.FlyEnemy:
                behaviour = new FlyEnemyBehaviour(this);
                break;
            case TypeOfEnemy.GroundEnemy:
                behaviour = new GroundEnemyBehaviour(this);
                break;
        }
    }
    void Update()
    {
        behaviour?.Move();
    }

    void OnDisable()
    {
        if(behaviour is FlyEnemyBehaviour fly)
        {
            fly?.ResetTimer();
        }
    }
}
