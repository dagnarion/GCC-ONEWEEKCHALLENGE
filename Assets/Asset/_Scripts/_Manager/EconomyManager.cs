using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : Singleton<EconomyManager>
{
    [field: SerializeField] public int CurrentMoney { get; private set; }
    // để tạm
    void Start()
    {
        ResetMoney();
    }
    public void ResetMoney()
    {
        CurrentMoney = 0;
    }

    public void IncreaseMoney(int amount)
    {
        CurrentMoney += amount;
    }

    public void DecreaseMoney(int amount)
    {
        if (!CanBuy(amount)) return;
        CurrentMoney -= amount;
    }

    public bool CanBuy(int amount) => CurrentMoney - amount > 0; 
}
