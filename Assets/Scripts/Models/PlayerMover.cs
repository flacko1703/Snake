using UnityEngine;

namespace Snake
{
    public class PlayerMover : IMove
    {
        private float _moveSpeed = 10;
        private Transform _instance;
        private CharacterController _characterController;
        private Vector2 _inputAxis;
        private Vector3 _moveDirection;
    
        public PlayerMover(CharacterController instance)
        {
            _instance = instance.transform;
            _characterController = instance;
        }
    
        public void Move()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            _inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 desiredMove = _instance.forward * _inputAxis.y + _instance.right * _inputAxis.x;
            _moveDirection.x = desiredMove.x * _moveSpeed;
            _moveDirection.y = desiredMove.y * _moveSpeed;
        
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}