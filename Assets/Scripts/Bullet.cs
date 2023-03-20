using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 500.0f;
    [SerializeField] private float _maxLifeTime = 10.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Project(Vector2 direction)
    { 
        _rigidbody.AddForce(direction * _speed);

        Destroy(gameObject, _maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
