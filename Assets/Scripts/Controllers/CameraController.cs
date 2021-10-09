namespace Snake
{
    public class CameraController : BaseController, IExecute, IInitialize, IMove
    {
        private CameraMover _cameraMover;
        
        
        public void Execute()
        {
            if (!IsActive) return;
            Move();
        }

        public void Move()
        {
            _cameraMover.FollowPlayer();
        }

        public void Initialize()
        {
            _cameraMover = ServiceLocatorMonoBehaviour.GetService<CameraMover>();
        }
    }
}