using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class PlasmaAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Атаковали плазмой");
        }
    }
}

