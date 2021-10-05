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
        
            _executeControllers = new IExecute[1];
            _executeControllers[0] = ServiceLocator.Resolve<PlayerController>();
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
        
        }
    }
}