
using UnityEngine;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Bullet _bulletPrefab;

        //[SerializeField] private Rigidbody2D _bullet;
        //[SerializeField] private Transform _barrel;
        //[SerializeField] private float _force;

        private Rigidbody2D _rigidbody;
        private Camera _camera;
        private Ship _ship;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var hp = new HPShip(_hp);
            var fire = new FireShip(_bulletPrefab, transform);
            _ship = new Ship(moveTransform, rotation, hp, fire);
        }


        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(_rigidbody, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
                bullet.Project(transform.up);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.Damage(20f);
            }
        }
    }
}