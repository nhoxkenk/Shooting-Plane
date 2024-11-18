using UnityEngine;
using UnityEngine.UI;

namespace PlaneShooter
{
    public class BossHealthBar : MonoBehaviour
    {
        [SerializeField] Boss boss;
        [SerializeField] Image healthBar;

        private void Awake()
        {
            boss.OnHealthChanged += HandleOnHealthChanged;
        }

        private void HandleOnHealthChanged()
        {
            healthBar.fillAmount = boss.GetHealthNormalized();
        }
    }
}
