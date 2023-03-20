using UnityEngine;



namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IHitPoints, IFire
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IHitPoints _hitPointsImplementation;
        private readonly IFire _fireImplementation;
        public float Speed => _moveImplementation.Speed;
        public float HP => _hitPointsImplementation.HP;

        public Ship(IMove moveImplementation, IRotation rotationImplementation, IHitPoints hitPointsImplementation, IFire fireImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _hitPointsImplementation = hitPointsImplementation;
            _fireImplementation = fireImplementation;
        }
        public void Move(Rigidbody2D rigidbody, float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(rigidbody, horizontal, vertical, deltaTime);
        }
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void Fire(Bullet bulletPrefab, Vector3 position, Quaternion rotation)
        {
            _fireImplementation.Fire(bulletPrefab, position, rotation);
        }

        public void Damage(float damage)
        {
            _hitPointsImplementation.Damage(damage);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
