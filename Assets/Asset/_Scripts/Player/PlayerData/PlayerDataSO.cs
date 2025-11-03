using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerDataSO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Deceleration { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
}
