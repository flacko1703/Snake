namespace Snake
{
    public class PlayerController : BaseController, IExecute
    {
        private readonly IMove _playerMover;

        public PlayerController(IMove mover)
        {
            _playerMover = mover;
        }

        public void Execute()
        {
            if (!IsActive) return;
            _playerMover.Move();
        }
    }
}
