using UnityEngine;

namespace Snake
{
    public class CameraMover : BaseSceneObject
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Vector3 _distance;
        private Camera _camera;

        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
            _distance = new Vector3(0,3,-8);
        }


        public void FollowPlayer()
        {
            _camera.transform.position = _targetPosition.transform.position + _distance;
        }

    }
}
