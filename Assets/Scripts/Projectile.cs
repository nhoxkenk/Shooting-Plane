using System;
using UnityEngine;

namespace PlaneShooter
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;
        Transform parent;
        public Action Callback;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;
        private void Start()
        {
            if(muzzlePrefab != null)
            {
                var muzzleVfx = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVfx.transform.forward = gameObject.transform.forward;
                muzzleVfx.transform.SetParent(parent);
                DestroyParticleSystem(muzzleVfx);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null)
            {
                var contactPoint = collision.contacts[0];
                var hitVfx = Instantiate(hitPrefab, contactPoint.point, Quaternion.identity);
                DestroyParticleSystem(hitVfx);
            }
            var plane = collision.gameObject.GetComponent<Plane>();
            if(plane != null)
            {
                plane.TakeDamage(10);
            }

            Destroy(gameObject);
        }

        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        private void DestroyParticleSystem(GameObject vfx)
        {
            var particle = vfx.GetComponent<ParticleSystem>();  
            if(particle == null)
            {
                particle = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, particle.main.duration);
        }
    }
}
