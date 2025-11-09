using UnityEngine;

public class EconomyManager : SingletonDonDestroyOnLoad<EconomyManager>
{
    [field: SerializeField] public int CurrentMoney { get; private set; }

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
