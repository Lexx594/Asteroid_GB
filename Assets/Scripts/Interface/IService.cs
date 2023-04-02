using UnityEngine;
using System.Collections.Generic;

namespace Asteroids.ServiceLocator
{
    public interface IService
    {
        void Fire(Transform transform, Queue<GameObject> Pool);
    }
}

