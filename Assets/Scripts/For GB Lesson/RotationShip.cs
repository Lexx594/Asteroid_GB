using Unity.Mathematics;
using UnityEngine;


namespace Asteroids
{
    internal sealed class RotationShip : IRotation
    {
        
        public float Speed { get;  }
        public RotationShip(float speed)
        {
            Speed = speed;
        }
        public void Rotation(Rigidbody2D rigidbody, float horizontal, float deltaTime)
        {
            float _turnDirection = horizontal * deltaTime * Speed * - 1f;            
            rigidbody.AddTorque(_turnDirection);
        }



    }
}

