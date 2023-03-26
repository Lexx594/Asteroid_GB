using UnityEngine;


namespace Asteroids

{
    internal class MoveTransform: IMove
    {
        private readonly Transform _transform;
        
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }
        public void Move(Rigidbody2D rigidbody, float vertical, float deltaTime)
        {
            //var speed = deltaTime * Speed;
            //_move.Set(0.0f, vertical * speed,  0.0f);
            rigidbody.AddForce(_transform.up * vertical * Speed);


            //_transform.localPosition += _move;
        }

    }
}

