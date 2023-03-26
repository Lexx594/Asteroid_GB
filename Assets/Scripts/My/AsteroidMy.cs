using Asteroids.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class AsteroidMy : MonoBehaviour, IAsteroidRotator
    {
        [SerializeField] private Sprite[] _sprites;

        [SerializeField] private int _minSpeedRotation = -10;
        [SerializeField] private int _maxSpeedRotation = 10;
        [SerializeField] private int _speedRotation;
        public int speedAsteroid = 0;
        public int HPMax;
        public int currentHP;
        Image _healtBar;

        public float size = 1f;
        public float minSize = 0.5f;
        public float maxSize = 2f;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private bool _asteroidDestroy;


        private void Awake()
        {
            _healtBar = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            size = Random.Range(minSize, maxSize);
            HPMax = (int)(size * 1000);
            speedAsteroid = HPMax;
        }

        private void Start()
        {
            _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
            this.transform.localScale = Vector3.one * size;
            _rigidbody.mass = size * 1000;
            gameObject.AddComponent<PolygonCollider2D>();
            _speedRotation = Random.Range(_minSpeedRotation, _maxSpeedRotation);
            HPMax = (int)(size * 1000);
            speedAsteroid = HPMax;
            currentHP = HPMax;
        }

        private void Update()
        {
            Rotation();
            if (currentHP <= 0)
            {
                _asteroidDestroy = true;
                //если половина размера астероида больше минимального размера астероидов то создаем 2 половины астероида
                if ((this.size * 0.5f) >= this.minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }
                Destroy(gameObject);
            }
            _healtBar.fillAmount = (float)currentHP / HPMax;

            if (HPMax == currentHP)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else { transform.GetChild(0).gameObject.SetActive(true); }

            transform.GetChild(0).transform.rotation = Quaternion.identity;
        }

        public void Rotation()
        {            
            transform.Rotate(new Vector3(0, 0, _speedRotation) * Time.deltaTime);
        }

        public void SetTrajectory(Vector2 direction)
        {
            _rigidbody.AddForce(direction * speedAsteroid);            
        }

        private void CreateSplit()
        {
            Vector2 position = this.transform.position;
            position += Random.insideUnitCircle * 0.8f;

            AsteroidMy half = Instantiate(this, position, this.transform.rotation);
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
