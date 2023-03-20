
using UnityEngine;

namespace Asteroids

{
    internal class FireShip : IFire
    {
        public Bullet _bulletPrefab;
        private readonly Transform _transform;
        public FireShip(Bullet bulletPrefab, Transform transform)
        {
            _bulletPrefab = bulletPrefab;
            _transform = transform;
        }
        public void Fire(Bullet bulletPrefab, Vector3 position, Quaternion rotation)
        {
            _bulletPrefab = bulletPrefab;
            _transform.position = position;
            _transform.rotation = rotation;
        }
    }
}

