using UnityEngine;

namespace Asteroids.Adapter
{
    public interface IAttack
    {
        void Attack(Bullet bulletPrefab, Vector3 shipPosition, Vector3 enemyPosition);
    }
}


