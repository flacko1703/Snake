using Unity.VisualScripting;
using UnityEngine;

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
            Debug.Log("Moving..");
        }

        public void Initialize()
        {
            _cameraMover = ServiceLocatorMonoBehaviour.GetService<CameraMover>();
        }
    }
}