using System.Collections;
using UnityEngine;

namespace PlaneShooter
{
    public class HealthItem : Item
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>() != null)
            {
                other.GetComponent<Player>().AddHealth(amount);
                Destroy(gameObject);
            }  
        }
    }
}
