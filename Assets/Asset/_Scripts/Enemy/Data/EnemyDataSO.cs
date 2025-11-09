using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyDataSO/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField] public TypeOfEnemy EnemyType { get; private set; }
    [field: SerializeField] public int BaseHp { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}
public enum TypeOfEnemy
{
    FlyEnemy, GroundEnemy
}