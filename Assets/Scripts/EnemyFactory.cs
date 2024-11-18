using UnityEngine;
using UnityEngine.Splines;

namespace PlaneShooter
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            var enemy = new EnemyBuilder()
                .SetBasePrefab(enemyType.EnemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.Speed)
                .Build();

            return enemy;
        }

        //More factory methods, for example enemies that do not follow a spline
    }
}
