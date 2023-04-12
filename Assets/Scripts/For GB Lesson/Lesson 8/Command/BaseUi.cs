using UnityEngine;

namespace Asteroids.Command
{
    internal abstract class BaseUi : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}
