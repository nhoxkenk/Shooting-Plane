using UnityEngine;
using Utilities;

namespace PlaneShooter
{
    [CreateAssetMenu(fileName = "Tracking Shot", menuName = "WeaponStrategy/TrackingShot")]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField] float trackingSpeed = 5f;
        Transform target;

        public override void Initialize()
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Player").transform);
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectile.GetComponent<Projectile>().Callback = () =>
            {
                //get direction to target with same Z as firepoint
                Vector3 direction = Vector3.zero;
                if (firePoint != null)
                {
                    direction = (target.position - firePoint.position).With(z: firePoint.position.z).normalized;
                }

                //rotate foward, with Z as the up direction(ie: 0, 0, 1 aka Vector forward)
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
            };

            Destroy(projectile, projectileLifeTime);
        }
    }
}
