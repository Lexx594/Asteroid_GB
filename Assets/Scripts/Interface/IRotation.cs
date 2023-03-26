using UnityEngine;
namespace Asteroids
{
    public interface IRotation
    {
        float Speed { get; }
        void Rotation(Rigidbody2D rigidbody,  float horizontal, float deltaTime);
    }
}

