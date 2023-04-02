using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids.ServiceLocator
{
    internal sealed class ExampleServiceLocator : MonoBehaviour
    {
        Transform _transform;

        private void Awake()
        {
            ServiceLocator.SetService<IService>(new Service());
        }
        private void Start()

        {
            _transform = transform;
            InvokeRepeating(nameof(AddFire), 1f, 1f);
        }

        void AddFire()
        {
            ServiceLocator.Resolve<IService>().Fire(_transform, TurretManager.Instance.rocketPool);
        }

    }






}
