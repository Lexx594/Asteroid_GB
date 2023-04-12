using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Asteroids.Chain_of_Responsibility
{
    internal sealed class Example : MonoBehaviour
    {
        public Player player;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                var root = new PlayerModifier(player);
                root.Add(new AddSpeedMoveModifier(player, 5));
                root.Add(new AddSpeedTurnModifier(player, 100));
                root.Handle();
            }
        }
    }
}
