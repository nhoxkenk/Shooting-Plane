using UnityEngine;

namespace PlaneShooter
{
    [CreateAssetMenu(fileName = "Triple Shot", menuName = "WeaponStrategy/TripleShot")]
    public class TripleShot : WeaponStrategy
    {
        [SerializeField] float spreadAngle = 15f;
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for (int i = 0; i < 3; i++)
            {
                var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.transform.Rotate(0, spreadAngle * (i - 1), 0);
                projectile.layer = layer;

                var projectileComponent = projectile.GetComponent<Projectile>();
                projectileComponent.SetSpeed(projectileSpeed);

                Destroy(projectile, projectileLifeTime);
            }
        }
    }
}
