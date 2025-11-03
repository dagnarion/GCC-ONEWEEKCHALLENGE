using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "BulletDataSO/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField] public TypeOfBullet type;
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
}
public enum TypeOfBullet
{
    SinBullet,NormalBullet
}