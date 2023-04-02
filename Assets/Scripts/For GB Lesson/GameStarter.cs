using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private Player _player;

        [Header("AsteroidSpawn")]
        [SerializeField] private float _spawnRate = 4.0f;
        [SerializeField] private int _spawnAmount = 1;

        private EnemyFactory _enemyFactory;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
            _player = FindObjectOfType<Player>();
            _enemyFactory = new EnemyFactory();
        }

        private void Spawn()
        {
            int numder = Random.Range(0, 3);
            switch (numder)
            {
                case 0:
                    for (int i = 0; i < _spawnAmount; i++)
                    {
                        _enemyFactory.CreateEnemy(EnemyType.GrayAsteroid, _player);
                    }
                    break;

                case 1:
                    for (int i = 0; i < _spawnAmount; i++)
                    {
                        _enemyFactory.CreateEnemy(EnemyType.RedAsteroid, _player);
                    }
                    break;

                case 2:
                    for (int i = 0; i < _spawnAmount; i++)
                    {
                        _enemyFactory.CreateEnemy(EnemyType.EnemyShip, _player);
                    }
                    break;
            }
        }
    }
}