using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBehaviour : IBehaviour
{
    EnemyMovement movement;
    float startY;
    float timer;
    float speed;
    float amplitude = 2f;
    float frequency = 2f;

    public FlyEnemyBehaviour(EnemyMovement _movement)
    {
        movement = _movement;
        startY = _movement.transform.position.y;
        timer = 0f;
        speed = movement.enemyData.Speed;
    }

    public void Move()
    {
        timer += Time.deltaTime;
        Vector2 pos = movement.transform.position;
        pos.x -= speed * Time.deltaTime;
        pos.y = startY + Mathf.Sin(timer * frequency) * amplitude;
        movement.rigi.MovePosition(pos);
    }
    public void ResetTimer()
    {
        timer = 0;
        speed = movement.enemyData.Speed;
    }
}
