﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlaneShooter
{
    public class BossStage : MonoBehaviour
    {
        public List<Enemy> enemySystems;
        public bool IsBossInvulnerable = false;

        private void Awake()
        {
            foreach (var system in enemySystems)
            {
                system.gameObject.SetActive(false);
            }
        }

        public void InitializeStage()
        {
            foreach(var system in enemySystems)
            {
                system.gameObject.SetActive(true);
            }
        }

        public bool IsStageComplete()
        {
            return enemySystems.All(system => system == null || !(system.GetHealthNormalized() > 0));
        }
    }
}
