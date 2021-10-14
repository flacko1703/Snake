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

        public Vector3 CameraPos => _cameraPos;

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            _cameraPos = new Vector3();
            _distance = _camera.transform.position - _targetPosition.transform.position;
            
        }


        public void FollowPlayer()
        {
            _cameraPos = new Vector3(2,
                _targetPosition.transform.position.y + _distance.y,
                _targetPosition.transform.position.z + _distance.z);
            _camera.transform.position = CameraPos;
        }

    }
}