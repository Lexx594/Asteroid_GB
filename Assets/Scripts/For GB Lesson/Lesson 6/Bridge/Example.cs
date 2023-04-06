using Asteroids.Adapter;
using UnityEngine;


namespace Asteroids.Bridge
{
    internal sealed class Example : MonoBehaviour
    {
        EnemyBridge _enemy;
        EnemyBridge _bulletFlyEnemy;
        EnemyBridge _plasmaFastFlyEnemy;
        EnemyBridge _rocketFlyEnemy;

        private void Start()
        {            
            _bulletFlyEnemy = new EnemyBridge(new BulletAttack(), new Fly());
            _plasmaFastFlyEnemy = new EnemyBridge(new PlasmaAttack(), new FastFly());
            _rocketFlyEnemy = new EnemyBridge(new RocketAttack(), new Fly());
            _enemy = _bulletFlyEnemy;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _enemy.Attack(); 
            if (Input.GetMouseButtonDown(1)) _enemy.Move();

            if (Input.GetKeyDown(KeyCode.Alpha1)) _enemy = _bulletFlyEnemy;
            else if (Input.GetKeyDown(KeyCode.Alpha2)) _enemy = _plasmaFastFlyEnemy;
            else if (Input.GetKeyDown(KeyCode.Alpha3)) _enemy = _rocketFlyEnemy;
        }
    }
}

