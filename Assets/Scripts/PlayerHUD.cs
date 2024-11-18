using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneShooter
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] Image fuelBar;
        [SerializeField] TextMeshProUGUI scoreText;

        private void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
            fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
            scoreText.text = string.Format($"Score: {GameManager.Instance.GetScore()}");
        }
    }
}
