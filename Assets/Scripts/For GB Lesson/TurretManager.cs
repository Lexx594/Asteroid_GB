using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TurretManager : MonoBehaviour
    {

        public static TurretManager Instance { get; private set; }
        [SerializeField] private Sprite _sprite;
        public Bullet _bulletPrefab;
        public Bullet _plasmaBallPrefab;
        Transform _transform;       
        const int POOL_BULLET_SIZE = 64;
        const int POOL_PLASMA_BALL_SIZE = 64;
        const int POOL_ROCKET_SIZE = 64;

        public Queue<Bullet> bulletPool = new Queue<Bullet>();
        public Queue<Bullet> plasmaBallPool = new Queue<Bullet>();
        public Queue<GameObject> rocketPool = new Queue<GameObject>();

        private void Awake()
        {
            Instance = this;
            _transform = transform;
        }

        void Start()
        {
            //заполняем ПУЛ
            for (int i = 0; i < POOL_BULLET_SIZE; i++)
            {
                Bullet ammo = Instantiate(_bulletPrefab, _transform.GetChild(0));
                ammo.gameObject.SetActive(false);
                bulletPool.Enqueue(ammo);
            }

            for (int i = 0; i < POOL_PLASMA_BALL_SIZE; i++)
            {
                Bullet ammo = Instantiate(_plasmaBallPrefab, _transform.GetChild(1));
                ammo.gameObject.SetActive(false);
                plasmaBallPool.Enqueue(ammo);
            }

            for (int i = 0; i < POOL_ROCKET_SIZE; i++)
            {
                var ammo = new GameObject()
                    .SetName("Rocket")
                    .AddRigidbody2D(1.0f, 0.0f, 0.0f)
                    .AddSprite(_sprite)
                    .AddPolygonCollider2D()
                    .AddScriptBullet(300f, 6f, 150);
                ammo.transform.parent = _transform.GetChild(2);
                ammo.gameObject.SetActive(false);
                rocketPool.Enqueue(ammo);
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

        public void AddFire(Transform transform, Queue<GameObject> Pool)
        {
            GameObject ammo = Pool.Dequeue();
            ammo.SetActive(true);
            ammo.transform.SetPositionAndRotation(transform.position, transform.rotation);
            ammo.GetComponent<Bullet>().Project(transform.up);
        }
    }
}
