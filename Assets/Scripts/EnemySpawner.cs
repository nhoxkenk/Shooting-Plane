using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace PlaneShooter
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;    
        int enemySpawned;

        private void OnValidate() => splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());

        private void Start() => enemyFactory = new EnemyFactory();

        private void Update()
        {
            spawnTimer += Time.deltaTime;

            if(enemySpawned < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }

        private void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];

            enemyFactory.CreateEnemy(enemyType, spline);
            enemySpawned++;
        }
    }
}
