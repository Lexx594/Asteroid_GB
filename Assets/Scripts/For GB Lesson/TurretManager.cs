using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TurretManager : MonoBehaviour
    {

        public static TurretManager Instance { get; private set; }
                
        public Bullet _bulletPrefab;
        public Bullet _plasmaBallPrefab;
        Transform _transform;
        const int POOL_BULLET_SIZE = 64;
        const int POOL_PLASMA_BALL_SIZE = 64;

        public Queue<Bullet> bulletPool = new Queue<Bullet>();
        public Queue<Bullet> plasmaBallPool = new Queue<Bullet>();              

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //заполняем ПУЛ
            for (int i = 0; i < POOL_BULLET_SIZE; i++)
            {
                _transform = transform;
                Bullet ammo = Instantiate(_bulletPrefab, _transform.GetChild(0));
                ammo.gameObject.SetActive(false);
                bulletPool.Enqueue(ammo);
            }

            for (int i = 0; i < POOL_PLASMA_BALL_SIZE; i++)
            {
                _transform = transform;
                Bullet ammo = Instantiate(_plasmaBallPrefab, _transform.GetChild(1));
                ammo.gameObject.SetActive(false);
                plasmaBallPool.Enqueue(ammo);
            }
        }

        public void AddFire(Transform transform, Queue<Bullet> Pool)
        {
            // извлекаем снаряд из ПУЛА
            Bullet ammo = Pool.Dequeue();
            ammo.gameObject.SetActive(true);
            ammo.transform.position = transform.position;
            ammo.transform.rotation = transform.rotation;
            ammo.Project(transform.up);
        }






    }
}
