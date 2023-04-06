namespace Asteroids.Bridge
{
    internal sealed class EnemyBridge
    {
        private readonly IAttack _attack;
        private readonly IMove _move;
        public EnemyBridge(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }
        public void Attack()
        {
            _attack.Attack();
        }
        public void Move()
        {
            _move.Move();
        }
    }
}

