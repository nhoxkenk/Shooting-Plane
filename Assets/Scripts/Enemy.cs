using UnityEngine;
using UnityEngine.Events;

namespace PlaneShooter
{
    public class Enemy : Plane
    {
        protected override void Die()
        {
            GameManager.Instance.AddScore(1);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;
    }
}
