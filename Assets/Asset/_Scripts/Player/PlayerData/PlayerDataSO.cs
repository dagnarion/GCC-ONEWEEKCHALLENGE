using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerDataSO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [field: Header("Health")]
    [field: SerializeField] public int BaseHp;
    [field:Header("Movement")]
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Deceleration { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
}
