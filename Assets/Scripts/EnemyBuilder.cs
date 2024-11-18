using System;
using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace PlaneShooter
{
    public class EnemyBuilder
    {
        GameObject enemyPrefab;
        GameObject weaponPrefab;
        float speed;
        SplineContainer spline;

        public EnemyBuilder SetBasePrefab(GameObject basePrefab)
        {
            enemyPrefab = basePrefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject weaponPrefab)
        {
            this.weaponPrefab = weaponPrefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            splineAnimate.Restart(true);

            instance.transform.position = spline.EvaluatePosition(0f);

            return instance;
        }
    }
}
