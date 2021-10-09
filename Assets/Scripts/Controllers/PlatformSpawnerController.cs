using Snake.ObjectPooler;
using UnityEngine;

namespace Snake
{
    public class PlatformSpawnerController : BaseController, IExecute, IInitialize
    { 
        private PlayerMover _player;
        private Camera _camera = Camera.main;
        private CameraMover _cameraMover;
        private float _spawnCooldown = 1f;
        private float _lastTime;
        
        private void SpawnPlatform()
        {
            if (CanSpawn())
            {
                Vector3 spawnPos = _camera.transform.position;
                var platform = Pool.Instance.GetFromPool();
                platform.transform.position = new Vector3(_camera.transform.position.x, 0, _camera.transform.position.z + 10);
                Debug.Log("Spawned");
            }
        }

        public void Execute() 
        {
            if (!IsActive) return;
            SpawnPlatform();
        }

        private bool CanSpawn()
        {
            if (_lastTime <= _spawnCooldown)
            {
                _lastTime += Time.deltaTime;
                return false;
            }
            else
            {
                _lastTime = 0;
                return true;
            }
        }


        public void Initialize()
        {
            _cameraMover = ServiceLocatorMonoBehaviour.GetService<CameraMover>();
        }
    }
}