


namespace Asteroids.Chain_of_Responsibility
{
    internal sealed class AddSpeedTurnModifier : PlayerModifier
    {
        private readonly float _maxSpeedTurn;
        public AddSpeedTurnModifier(Player player, int maxSpeedTurn)
        : base(player)
        {
            _maxSpeedTurn = maxSpeedTurn;
        }
        public override void Handle()
        {
            if (_player._speedTurn < _maxSpeedTurn)
            {
                _player._speedTurn += 10;
            }
            base.Handle();
        }
    }
}
