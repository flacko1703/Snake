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
            _inputAxis = new Vector2(Input.GetAxis("Horizontal"), 0);
            Vector3 desiredMove = _instance.right * _inputAxis.x + _instance.forward + _instance.up;
            _moveDirection.x = desiredMove.x * _moveSpeed;
            _moveDirection.z = desiredMove.y * _moveSpeed;
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}