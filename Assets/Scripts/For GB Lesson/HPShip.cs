using UnityEngine;


namespace Asteroids
{
    internal sealed class HPShip : IHitPoints
    {
        //private float _damage;

        public float HP { get;  set; }

        public HPShip(float hp)
        {
            HP = hp;
        }
        public void Damage(float damage)
        {
            HP -= damage;
        }
    }
}


