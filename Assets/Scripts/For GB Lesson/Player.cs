using UnityEngine.UI;
using UnityEngine;



namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        public float _speed = 1f;
        public float _speedTurn = 1f;
        [SerializeField] private float _acceleration = 1f;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _hpMax = 1000;
        [SerializeField] private int _currentHP;

        private Rigidbody2D _rigidbody;        
        private Ship _ship;
        public Image healtBar;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            healtBar = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>();
        }

        private void Start()
        {            
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(_speedTurn);
            _ship = new Ship(moveTransform, rotation);
            _currentHP = _hpMax;
        }

        private void Update()
        {            
            _ship.Rotation(_rigidbody, Input.GetAxis("Horizontal") , Time.deltaTime);
            _ship.Move(_rigidbody, Input.GetAxis("Vertical") , Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            healtBar.fillAmount = (float)_currentHP / _hpMax;
            if (_hpMax == _currentHP) transform.GetChild(0).gameObject.SetActive(false);
            else transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.rotation = Quaternion.identity;

            if (_currentHP <= 0)
            {
                Destroy(gameObject);
            }

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Bullet")
            {
                _currentHP -= other.gameObject.GetComponent<Bullet>().damage;  
            }
            else if (other.gameObject.tag == "Asteroid")
            {
                DamageUI.instance.AddText(other.gameObject.GetComponent<Asteroid>().damage, transform.position);
                _currentHP -= other.gameObject.GetComponent<Asteroid>().damage;
            }
        }
    }
}