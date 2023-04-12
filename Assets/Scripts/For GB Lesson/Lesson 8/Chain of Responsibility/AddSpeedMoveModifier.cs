

namespace Asteroids.Chain_of_Responsibility
{
    internal sealed class AddSpeedMoveModifier : PlayerModifier
    {
        private readonly float _speed;
        public AddSpeedMoveModifier(Player player, float speed)
        : base(player)
        {
            _speed = speed;
        }
        public override void Handle()
        {
            _player._speed += _speed;
            base.Handle();
        }
    }
}