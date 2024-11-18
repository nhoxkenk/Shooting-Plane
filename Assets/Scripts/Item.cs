using UnityEngine;

namespace PlaneShooter
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected float amount = 10f;
    }
}
