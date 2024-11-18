using UnityEngine;

namespace PlaneShooter
{
    public class PlayerWeapon : Weapon
    {
        InputReader inputReader;
        float fireTimer;

        private void Awake() => inputReader = GetComponent<InputReader>();

        private void Update()
        {
            fireTimer += Time.deltaTime;

            if (inputReader.Fire && fireTimer >= strategy.FireRate)
            {
                strategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
