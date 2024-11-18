using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace PlaneShooter
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] string startingLevel;
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;

        private void Awake()
        {
            playButton.onClick.AddListener(() => Loader.Load(startingLevel));
            quitButton.onClick.AddListener(() => Helpers.QuitGame());
            Time.timeScale  = 1.0f;
        }

    }
}
