using UnityEngine;

namespace Asteroids
{
    public class StationTurret : MonoBehaviour
    {

        [SerializeField] private float  _attackRange;
        [SerializeField] private float _turret_rotation_speed = 5f;
        public LayerMask whatIsAsteroid;
        private bool _attack;
        Transform _transform;

        void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, _attackRange, new Vector2(0,0), _attackRange, whatIsAsteroid);
            if (hit.collider != null && !_attack)
            {
                _attack = true;
                Vector2 turretPosition = new Vector2(transform.position.x, transform.position.y);
                Vector3 direction = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y) - turretPosition;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) *
                    Mathf.Rad2Deg) - 90f, _turret_rotation_speed * Time.deltaTime)));

                TurretManager.Instance.AddFire(_transform, TurretManager.Instance.plasmaBallPool);
                Invoke(nameof(ResetAttack), 0.5f);
            }
        }
        void ResetAttack()
        {
            _attack = false;
        }
    }
}
