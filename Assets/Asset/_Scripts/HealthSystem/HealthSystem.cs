using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    int BaseHp;
    int currentHp;
    public void Init(int _BaseHp)
    {
        BaseHp = _BaseHp;
    }
    public void Reborn()
    {
        currentHp = BaseHp;
    }

    public void Detuc(int amount)
    {
        if (!IsAlive()) return;
        currentHp -= amount;
    }

    public bool IsAlive() => currentHp > 0;
}
