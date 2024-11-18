using UnityEngine;

namespace PlaneShooter
{
    public class EnemyWeapon : Weapon
    {
        float fireTimer;

        private void Update()
        {
            fireTimer += Time.deltaTime;

            if(fireTimer >= strategy.FireRate)
            {
                strategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
