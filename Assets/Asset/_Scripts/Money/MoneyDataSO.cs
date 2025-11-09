using UnityEngine;
[CreateAssetMenu(menuName = "MoneyDataSO/MoneyData")]
public class MoneyDataSO : ItemData
{
    [field:SerializeField] public int amount { get; private set; }
}
