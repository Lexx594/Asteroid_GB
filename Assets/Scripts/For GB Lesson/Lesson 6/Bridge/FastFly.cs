using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class FastFly : IMove
    {
        public void Move()
        {
            Debug.Log("Быстро полетели");
        }
    }
}

