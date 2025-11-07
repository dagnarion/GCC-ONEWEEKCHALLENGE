using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MoneyDataSO/MoneyData")]
public class MoneyDataSO : ItemData
{
    [field:SerializeField] public int amount { get; private set; }
}
