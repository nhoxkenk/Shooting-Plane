using UnityEngine;

namespace PlaneShooter
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] string mainSceneName;
        [SerializeField] GameObject gameOverUI;

        Player player;
        Boss boss;
        public Player Player => player;
        int score;
        float restartTimer = 3f;
        private void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }

        private void Update()
        {
            if(IsGameOver())
            {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0 )
                {
                    Loader.Load(mainSceneName);
                }
            }
        }

        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0 || boss.GetHealthNormalized() <= 0;
        public void AddScore(int amount) => score += amount;
        public int GetScore() => score; 

    }

}
