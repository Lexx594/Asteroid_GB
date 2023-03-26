using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(Rigidbody2D rigidbody, float vertical, float deltaTime);
    }
}

