using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class RocketAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Атаковали ракетами");
        }
    }
}

