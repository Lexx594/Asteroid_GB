using Asteroids;


namespace Asteroids.Chain_of_Responsibility
{
    internal class PlayerModifier
    {
        protected Player _player;
        protected PlayerModifier Next;
        public PlayerModifier(Player player)
        {
            _player = player;
        }
        public void Add(PlayerModifier plMod)
        {
            if (Next != null)
            {
                Next.Add(plMod);
            }
            else
            {
                Next = plMod;
            }
        }
        public virtual void Handle() => Next?.Handle();
    }
}
