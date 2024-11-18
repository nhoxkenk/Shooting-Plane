using UnityEngine;
using Utilities;

namespace PlaneShooter
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponStrategy strategy;
        [SerializeField] protected Transform firePoint;
        [SerializeField, Layer] protected LayerMask layer;

        private void OnValidate() => layer = gameObject.layer;

        private void Start() => strategy.Initialize();

        public void SetWeaponStrategy(WeaponStrategy weaponStrategy)
        {
            strategy = weaponStrategy;
            strategy.Initialize();
        }
    }
}
