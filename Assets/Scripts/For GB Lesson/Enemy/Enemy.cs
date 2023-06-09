using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    [RequireComponent(typeof (Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public int HPMax;
        public int currentHP;

        public Image healtBar;

        public delegate void SubjectHandler();
        public event SubjectHandler NotifyObserversEvent;

        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody == null) rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;            
            healtBar = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Image>();
        }


        protected virtual void Start()
        {
            currentHP = HPMax;
            VisitorEnemy visitor = new VisitorEnemy();
            Accept(visitor);
        }


        protected virtual void Update()
        {
            healtBar.fillAmount = (float)currentHP / HPMax;
            if (HPMax == currentHP) transform.GetChild(0).gameObject.SetActive(false);
            else transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.rotation = Quaternion.identity;
        }

        public void Accept(VisitorEnemy visitor)
        {
            visitor.visit(this);
        }

        private void OnDestroy()
        {
            NotifyObserversEvent?.Invoke();
        }


    }
}

