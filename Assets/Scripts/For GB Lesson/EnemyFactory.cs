using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyFactory
    {

        [Header("AsteroidSpawn")]
        [SerializeField] private float _spawnDistance = 12.0f;
        [SerializeField] private float _trajectoryVariance = 15.0f;

        public Enemy CreateEnemy(EnemyType enemyType, Player player)
        {
            Vector3 spawnDirection, spawnPoint;            
            Quaternion rotation;

            switch (enemyType)
            {
                case EnemyType.GrayAsteroid:
                    FindPlayer();
                    Asteroid grayAsteroid = Asteroid.Instantiate(Resources.Load<Asteroid>("Enemy/GrayAsteroid"), spawnPoint, rotation);
                    grayAsteroid.SetTrajectory(rotation * -spawnDirection * 10f);
                    return grayAsteroid;

                case EnemyType.RedAsteroid:
                    FindPlayer();
                    Asteroid redAsteroid = Asteroid.Instantiate(Resources.Load<Asteroid>("Enemy/RedAsteroid"), spawnPoint, rotation);
                    redAsteroid.SetTrajectory(rotation * -spawnDirection * 10f);
                    return redAsteroid;

                case EnemyType.GreenAsteroid:
                    Asteroid greenAsteroid = Asteroid.Instantiate(Resources.Load<Asteroid>("Enemy/GreenAsteroid"));
                    return greenAsteroid;

                case EnemyType.EnemyShip:
                    FindPlayer();
                    EnemyShip enemyShip = EnemyShip.Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"), spawnPoint, rotation);
                    return enemyShip;

                default:
                    return null;

            }

            void FindPlayer()
            {
                spawnDirection = Random.insideUnitCircle.normalized * _spawnDistance;
                spawnPoint = player.transform.position + spawnDirection;
                rotation = Quaternion.AngleAxis(Random.Range(-_trajectoryVariance, _trajectoryVariance), Vector3.forward);
            }

        }

        



    }


}









