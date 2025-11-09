using UnityEngine;

public class GroundEnemyBehaviour : IBehaviour
{
    EnemyMovement movement;
    public GroundEnemyBehaviour(EnemyMovement _movement)
    {
        movement = _movement;
    }
    public void Move()
    {
        float speed = movement.enemyData.Speed;
        movement.rigi.velocity = Vector2.left * (speed+LevelManager.Instance.CurrentSpeed);
    }

}
