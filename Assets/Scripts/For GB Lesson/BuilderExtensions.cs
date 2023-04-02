using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }
        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return gameObject;
        }
        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float angularDrag)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.angularDrag = angularDrag;
            return gameObject;
        }
        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float angularDrag, float gravityScale)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.angularDrag = angularDrag;
            component.gravityScale = gravityScale;
            return gameObject;
        }
        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }
        public static GameObject AddPolygonCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<PolygonCollider2D>();
            return gameObject;        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        public static GameObject AddScriptBullet(this GameObject gameObject, float speed, float maxLifeTime, int damage)
        {
            var component = gameObject.GetOrAddComponent<Bullet>();
            component.speed = speed;
            component.maxLifeTime = maxLifeTime;
            component.damage = damage;
            return gameObject;
        }
       
        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}

