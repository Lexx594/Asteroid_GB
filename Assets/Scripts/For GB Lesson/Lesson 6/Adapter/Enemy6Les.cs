using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Adapter
{
    internal sealed class Enemy6Les : MonoBehaviour
    {
        private Camera _camera;
        Adapter _adapter;
        public Bullet _bulletPrefab;

        private void Awake()
        {
            _camera = Camera.main;
            _adapter = new Adapter();
        }

        private void Start()
        {            
            _adapter.shipPosition = this.transform.position;
            _adapter.bulletPrefab = _bulletPrefab;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;
                mousePos.z = 20.0f;
                var objectPos = _camera.ScreenToWorldPoint(mousePos);

                _adapter.Fire(objectPos);
            }
        }
    }
}

