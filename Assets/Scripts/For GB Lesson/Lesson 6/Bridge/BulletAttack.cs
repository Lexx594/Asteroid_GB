using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class BulletAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Атаковали пулями");
        }
    }
}
