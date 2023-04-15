using UnityEngine;

namespace Asteroids
{
    public class VisitorEnemy
    {
        public virtual void visit(Enemy enemy)
        {
            Debug.Log("New Enemy: " + enemy.ToString());
        }
    }
}