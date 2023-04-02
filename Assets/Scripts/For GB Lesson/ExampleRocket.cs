
using UnityEngine;

namespace Asteroids
{
    //Это пробный скрипт созданный чтобы разобраться в теме. Создание ракет реализовано в скрипте TurretManager


    public class ExampleRocket : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;        
        Transform _transform;

        private void Start()
        {
            //RocketBild();
            _transform = transform;
        }


        public void RocketBild()
        {            
            var rocketObject = new GameObject()
                .SetName("Rocket")
                .AddRigidbody2D(1.0f, 0.0f, 0.0f)
                .AddSprite(_sprite)
                .AddPolygonCollider2D()
                .AddScriptBullet(300f, 6f, 150);
        }
    }
}
