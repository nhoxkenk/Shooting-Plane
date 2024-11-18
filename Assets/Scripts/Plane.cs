
using UnityEngine;

namespace PlaneShooter
{
    public abstract class Plane : MonoBehaviour {
        [SerializeField] int maxHealth;
        int health;

        protected virtual void Awake() => health = maxHealth;
        public void SetMaxHealth(int amount) => maxHealth = amount;
        public void TakeDamage(int amount)
        {
            health -= amount;
            if(health <= 0)
            {
                Die();
            }
        }
        public float GetHealthNormalized() => health / (float)maxHealth;
        protected abstract void Die();
        public float AddHealth(float value) => health += (int)value;

    }
}
