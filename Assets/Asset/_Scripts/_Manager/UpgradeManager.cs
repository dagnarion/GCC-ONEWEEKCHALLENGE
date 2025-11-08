using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] UpgradeType[] items;
}

public enum TypeOfUpgrade
{
    BulletAmount = 0,BulletDamage = 1,Health = 2
}

[Serializable]
public struct UpgradeType
{
    [field:SerializeField] public TypeOfUpgrade Type { get; private set; }
    [field:SerializeField] public int Price { get; private set; }
    [field:SerializeField] public int Value { get; private set; }
    public void IncreasePrice(int Amount)
    {
        Price += Amount;
    }
    public void IncreaseValue(int Amount)
    {
        Value += Amount;
    }
}