using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IHitPoints
    {
        float HP { get;  }
        void Damage(float damage);
    }
}

