using UnityEngine;

namespace PlaneShooter
{
    public class Player : Plane
    {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;

        float fuel;
        private void Start() => fuel = maxFuel;

        private void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
        public float GetFuelNormalized() => fuel / (float)maxFuel;

        protected override void Die()
        {
            
        }
        public float AddFuel(float value) => fuel += value;
    }
}
