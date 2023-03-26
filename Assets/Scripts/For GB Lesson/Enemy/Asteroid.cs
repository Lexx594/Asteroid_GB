using Asteroids.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class Asteroid : Enemy, IAsteroidRotator
    {

        [SerializeField] private Sprite[] _sprites;

        [Header("AsteroidRotation")]
        [SerializeField] private int _speedRotation = 1;
        [SerializeField] private int _minSpeedRotation = -10;
        [SerializeField] private int _maxSpeedRotation = 10;

        public int speedAsteroid = 0;
        
        [Header("AsteroidSize")]
        public float size = 1f;
        public float minSize = 0.5f;
        public float maxSize = 2f;
        public int damage;

        private SpriteRenderer _spriteRenderer;        
        private bool _asteroidDestroy;


        protected override void Awake()
        {
            base.Awake();            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            size = Random.Range(minSize, maxSize);
            HPMax = (int)(size * 200);
            speedAsteroid = HPMax;
        }

        protected override void Start()
        {
            base.Start();
            _speedRotation = Random.Range(_minSpeedRotation, _maxSpeedRotation);
            _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
            transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
            transform.localScale = Vector3.one * size;
            rigidbody.mass = size * 1000;
            gameObject.AddComponent<PolygonCollider2D>(); 
            speedAsteroid = HPMax;
            damage = (int)(size * 50);
        }

        protected override void Update()
        {
            base.Update();
            Rotation();
            if (currentHP <= 0)
            {
                _asteroidDestroy = true;                
                if ((this.size * 0.5f) >= this.minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }
                Destroy(gameObject);
            }
        }

        public void Rotation()
        {
            transform.Rotate(new Vector3(0, 0, _speedRotation) * Time.deltaTime);
        }

        public void SetTrajectory(Vector2 direction)
        {
            rigidbody.AddForce(direction * speedAsteroid);
        }

        private void CreateSplit()
        {
            Vector2 position = this.transform.position;
            position += Random.insideUnitCircle * 0.8f;
            Asteroid half = Instantiate(this, position, this.transform.rotation);
            half.size = this.size * 0.5f;
            Destroy(half.gameObject.GetComponent<PolygonCollider2D>());
            half.SetTrajectory(Random.insideUnitCircle.normalized * speedAsteroid * 0.05f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet" && !_asteroidDestroy)
            {
                if (currentHP > 0)
                {
                    currentHP -= collision.gameObject.GetComponent<Bullet>().damage;
                }
            }
        }






    }
}

