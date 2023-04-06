using UnityEngine;


namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        private void Start()
        {       
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _fire = new Weapon(ammunition, _barrelPosition, 999.0f,
            _audioSource, _audioClip);
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}

