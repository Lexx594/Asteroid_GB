using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class Fly : IMove
    {
        public void Move()
        {
            Debug.Log("Полетели");
        }
    }
}

