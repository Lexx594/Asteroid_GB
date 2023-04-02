using System.Collections.Generic;
using UnityEngine;


namespace Asteroids.ServiceLocator
{
    internal sealed class Service : IService
    {
        public void Fire(Transform transform, Queue<GameObject> Pool)
        {
            TurretManager.Instance.AddFire(transform, Pool);
        }
    }
}

