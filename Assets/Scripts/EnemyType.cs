using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneShooter
{
    [CreateAssetMenu(fileName = "Enemy Type", menuName = "Enemy/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject EnemyPrefab;
        public GameObject EnemyWeapon;
        public float Speed;
    }
}
