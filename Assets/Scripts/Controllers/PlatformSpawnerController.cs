using System.Collections.Generic;
using System.Linq;
using Snake.ObjectPooler;
using UnityEngine;
using System.Linq;
using System.Xml.Linq;

namespace Snake
{
    public class PlatformSpawnerController : BaseController, IExecute, IInitialize
    { 
        private PlayerMover _player;
        private Camera _camera = Camera.main;
        private CameraMover _cameraMover;
        private float _spawnCooldown = 1f;
        private float _lastTime = 1f;
        private float _destroyTime = 1f;
        private Vector3 _spawnPos = new Vector3(0,0,20);
        private List<GameObject> _platforms = new List<GameObject>();
        
        
        private void SpawnPlatform()
        {
            if (CanSpawn() && _platforms.Count <= 3)
            {
                Vector3 spawnPos = _camera.transform.position;
                var platform = Pool.Instance.GetFromPool();
                _platforms.Add(platform);
                platform.transform.position = new Vector3(0, 0, _camera.transform.position.z + 10);
                if (_platforms.Count >= 2)
                {
                    for (int i = 0; i < _platforms.Count - 1; i++)
                    {
                        Pool.Instance.AddToPool(_platforms.ElementAt(i));
                    }

                    _platforms.RemoveRange(0, _platforms.Count - 1);

                }
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

        private bool CanClear()
        {
            if (_destroyTime <= _spawnCooldown)
            {
                _destroyTime += Time.deltaTime;
                return false;
            }
            else
            {
                _destroyTime = 0;
                return true;
            }
        }

        private void ClearUnusedPlatforms(GameObject platform)
        {
            Pool.Instance.AddToPool(platform);
        }


        public void Initialize()
        {
            _spawnPos = new Vector3();
            _cameraMover = UnityEngine.Object.FindObjectOfType<CameraMover>();
        }
    }
}