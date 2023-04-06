using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids.Adapter
{
    internal sealed class Adapter :  IFire
    {
        private readonly IAttack _attack = new AttackBullet();
        public Vector3 shipPosition { get; set; }

        public Bullet bulletPrefab;

        public void Fire(Vector3 position)
        {
            _attack.Attack(bulletPrefab, shipPosition, position);            
        }
    }
}

