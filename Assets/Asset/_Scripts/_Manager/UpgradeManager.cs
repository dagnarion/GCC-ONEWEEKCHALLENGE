using System;
using UnityEngine;

public class UpgradeManager : SingletonDonDestroyOnLoad<UpgradeManager>
{
    [SerializeField] int MaxBulletAmount = 5;
    [SerializeField] int MaxBulletDamage = 5;
    [SerializeField] int MaxHealth = 3;
    [SerializeField] Upgrade[] upgrades;
    public int BulletDamage { get; private set; }
    public int BulletAmount { get; private set; }
    public int Health { get; private set; }
    public void ResetValue()
    {
        BulletAmount = 0;
        BulletDamage = 0;
        Health = 0;
    }
    public void IncreaseBulletDamage()
    {
        Upgrade obj = ChooseItem(TypeOfUpgrade.BulletDamage);
        if (obj == null || !EconomyManager.Instance.CanBuy(obj.Price) || BulletDamage >= MaxBulletDamage) return;
        BulletDamage += obj.Value;
        EconomyManager.Instance.DecreaseMoney(obj.Price);
    }
    public void IncreaseHealth()
    {
        Upgrade obj = ChooseItem(TypeOfUpgrade.Health);
        if (obj == null || !EconomyManager.Instance.CanBuy(obj.Price) || Health >= MaxHealth) return;
        Health += obj.Value;
        EconomyManager.Instance.DecreaseMoney(obj.Price);
    }
    public void IncreaseBulletAmount()
    {
        Upgrade obj = ChooseItem(TypeOfUpgrade.BulletAmount);
        if (obj == null || !EconomyManager.Instance.CanBuy(obj.Price) || BulletAmount >= MaxBulletAmount) return;
        BulletAmount += obj.Value;
        EconomyManager.Instance.DecreaseMoney(obj.Price);
    }

    Upgrade ChooseItem(TypeOfUpgrade type)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i].type == type) return upgrades[i];
        }
        return null;
    }

}
public enum TypeOfUpgrade
{
    Invalid = 0, BulletAmount = 1, BulletDamage = 2, Health = 3
}
[Serializable]
public class Upgrade
{
    [field: SerializeField] public TypeOfUpgrade type { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}

/// Maybe need in the future