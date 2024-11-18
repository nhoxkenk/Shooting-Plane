using System.Collections;
using UnityEngine;

namespace PlaneShooter
{
    public class FuelItem : Item
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().AddFuel(amount);
                Destroy(gameObject);

            }
        }
    }
}
