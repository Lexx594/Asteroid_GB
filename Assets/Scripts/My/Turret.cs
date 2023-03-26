using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Asteroids
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        Transform _transform;

        void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _transform.up += transform.up * 2f;
                TurretManager.Instance.AddFire(_transform, TurretManager.Instance.bulletPool);
            }
        }
    }
}
 