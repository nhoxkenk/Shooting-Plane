using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneShooter
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        float health;

        Collider bossCollider;

        [SerializeField] List<BossStage> stages;
        int currentStage = 0;

        private void Awake() => bossCollider = GetComponent<Collider>();
        public event Action OnHealthChanged = delegate { };
        private void Start()
        {
            health = maxHealth;
            bossCollider.enabled = true;

            InitializeStage();
        }

        public float GetHealthNormalized() => health / maxHealth;

        void CheckStageComplete()
        {
            if (stages[currentStage].IsStageComplete()){
                AdvanceToNextStage();
            }
        }

        void AdvanceToNextStage()
        {
            currentStage++;
            bossCollider.enabled = true;

            if(currentStage < stages.Count)
            {
                InitializeStage();
            }
        }

        void InitializeStage()
        {
            stages[currentStage].InitializeStage();

            //Handle Stage
            foreach (var stage in stages)
            {
                foreach (var system in stage.enemySystems)
                {
                    system.OnSystemDestroyed.AddListener(CheckStageComplete);
                }
            }

            bossCollider.enabled = !stages[currentStage].IsBossInvulnerable;
        }

        private void OnCollisionEnter(Collision collision)
        {
            health -= 10;
            OnHealthChanged?.Invoke();
            if(health <= 0)
            {
                BossDefeated();
            }
        }

        void BossDefeated()
        {
            Debug.Log("Defeated");
        }
    }
}
