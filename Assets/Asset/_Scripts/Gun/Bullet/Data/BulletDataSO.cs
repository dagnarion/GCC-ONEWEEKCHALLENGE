using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "BulletDataSO/BulletData")]
public class BulletDataSO : ItemData
{
    [field: SerializeField] public TypeOfBullet type { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
}

public enum TypeOfBullet
{
    NozmalBullet = 0, SineBullet = 1, PerlinBullet = 2
}