using UnityEngine;

namespace Snake
{
    public class CameraMover : BaseSceneObject
    {
        [SerializeField] private Transform _targetPosition;
        private Vector3 _distance;
        private Camera _camera;
        private Vector3 _cameraPos;

        public Vector3 Distance => _distance;

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            _distance = _camera.transform.position - _targetPosition.transform.position;
            
        }


        public void FollowPlayer()
        {
            _cameraPos = new Vector3(0,
                _targetPosition.transform.position.y + _distance.y,
                _targetPosition.transform.position.z + _distance.z);
            _camera.transform.position = _cameraPos;
        }

    }
}