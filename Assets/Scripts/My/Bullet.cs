using UnityEngine;


namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D _rigidbody;
        public float speed = 500.0f;
        public float maxLifeTime = 5.0f;
        public int damage = 100;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Project(Vector2 direction)
        {
            _rigidbody.AddForce(direction * speed);
            Invoke(nameof(AddPool), maxLifeTime);
            Invoke(nameof(AddCollaider), 0.1f);
        }

        public void AddCollaider() { gameObject.AddComponent<PolygonCollider2D>(); }

        private void AddPool()
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
            gameObject.SetActive(false);
            if (gameObject.name == "Bullet(Clone)") TurretManager.Instance.bulletPool.Enqueue(this);
            else if (gameObject.name == "Plasma Ball(Clone)") TurretManager.Instance.plasmaBallPool.Enqueue(this);
            else if (gameObject.name == "Rocket") TurretManager.Instance.rocketPool.Enqueue(gameObject);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            DamageUI.instance.AddText(damage, transform.position);
            AddPool();
        }
    }
}
