using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Asteroids
{
    public class EnemyShip : Enemy
    {
        private Player _player;
        [SerializeField] private float _attackRange = 5f;
        [SerializeField] private float _sightRange = 10f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private LayerMask _whatIsAsteroid, _whatIsPlayer;
        private bool _attack;
        public int speedShip = 1;
        Transform _transform;
        

        protected override void Start()
        {
            base.Start();
            _player = FindObjectOfType<Player>();
            _transform = transform;
        }


        protected override void Update()
        {
            base.Update();
            if (currentHP <= 0)
            {                
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            float distance = Vector2.Distance(transform.position, _player.transform.position);
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, _sightRange, new Vector2(0, 0), _sightRange, _whatIsAsteroid);
            if (hit.collider != null && Vector2.Distance(transform.position, hit.collider.transform.position) < 5f) TurnFromObject(hit.collider.transform.position);
            else if (distance < _sightRange) TurnToObject(_player.transform.position);


            if (hit.collider != null && Vector2.Distance(transform.position, hit.collider.transform.position) < 5f)
            {                
                transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, -speedShip * Time.deltaTime);
            }
            else if (distance < _sightRange && distance > _attackRange)            
            {                
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speedShip * Time.deltaTime);
            }
            else if (distance < _sightRange && distance < _attackRange && !_attack)            
            {                
                transform.position = transform.position;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up), Color.red);
                RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f, _whatIsPlayer);
                if(hitPlayer.collider != null && hitPlayer.collider.tag == "Player")
                {
                    _attack = true;
                    TurretManager.Instance.AddFire(_transform, TurretManager.Instance.bulletPool);
                    Invoke(nameof(ResetAttack), 0.3f);
                }

            }
        }


        private void TurnToObject(Vector3 objectTransformPosition)
        {
            Vector3 direction = objectTransformPosition - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) *
                Mathf.Rad2Deg) - 90f, _rotationSpeed * Time.deltaTime)));
        }

        private void TurnFromObject(Vector3 objectTransformPosition)
        {
            Vector3 direction = objectTransformPosition - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(-direction.y, -direction.x) *
                Mathf.Rad2Deg) - 90f, _rotationSpeed * Time.deltaTime)));
        }

        private void LookAtPlayer()
        {
            Vector2 directionToEnemy = _player.transform.position - transform.position;
            float angleToEnemy = Vector2.Angle(directionToEnemy, transform.up);
            transform.Rotate(0, 0, angleToEnemy * _rotationSpeed * Time.deltaTime);
        }


        void ResetAttack()
        {
            _attack = false;
        }



        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Bullet")
            {
                currentHP -= other.gameObject.GetComponent<Bullet>().damage;
            }
            else if (other.gameObject.tag == "Asteroid")
            {
                DamageUI.instance.AddText(other.gameObject.GetComponent<Asteroid>().damage, transform.position);
                currentHP -= other.gameObject.GetComponent<Asteroid>().damage;
            }
        }




    }
}
