using UnityEngine;

namespace Snake
{
    public class Controllers : IInitialize
    {
        private readonly IExecute[] _executeControllers;
        public int Length => _executeControllers.Length;

        public Controllers()
        {
            IMove mover = new PlayerMover(ServiceLocatorMonoBehaviour.GetService<CharacterController>());
        
            ServiceLocator.SetService(new PlayerController(mover));
            ServiceLocator.SetService(new CameraController());
        
            _executeControllers = new IExecute[5];
            _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
            _executeControllers[1] = ServiceLocator.Resolve<CameraController>();
        }
    
        public IExecute this[int index] => _executeControllers[index];

        public void Initialize()
        {
            foreach (var controller in _executeControllers)
            {
                if (controller is IInitialize initialization)
                {
                    initialization.Initialize();
                }
            }
        
            ServiceLocator.Resolve<PlayerController>().On();
            ServiceLocator.Resolve<CameraController>().On();
        
        }
    }
}