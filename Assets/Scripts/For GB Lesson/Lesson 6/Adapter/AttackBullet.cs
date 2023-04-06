using UnityEngine;

namespace Asteroids.Adapter
{
    internal sealed class AttackBullet : MonoBehaviour, IAttack
    {        
        public void Attack(Bullet bulletPrefab, Vector3 shipPosition, Vector3 enemyPosition)
        {
            var direction = Quaternion.Euler(enemyPosition - shipPosition);
            Bullet bullet = Instantiate(bulletPrefab, shipPosition, direction);            
            Vector2 directionV2 = new Vector2(direction.x, direction.y);
            bullet.Project(directionV2);
        }
    }
}

