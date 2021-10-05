using UnityEngine;

namespace Snake
{
    public class MainController : MonoBehaviour
    {
        private Controllers _controllers;
        private void Start()
        {
            _controllers = new Controllers();
            _controllers.Initialize();
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i]?.Execute();
            }
        }
    }
}