using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IFire
    {        
        void Fire(Bullet _bulletPrefab, Vector3 position, Quaternion rotation);
    }
}

