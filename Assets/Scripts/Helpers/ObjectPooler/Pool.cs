using System.Collections.Generic;
using UnityEngine;

namespace Snake.ObjectPooler
{
    public class Pool : BaseSceneObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _objectsInPool;

        public Queue<GameObject> _availableObjects = new Queue<GameObject>();

        public static Pool Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
            FillPool();
        }

        public GameObject GetFromPool()
        {
            if (_availableObjects.Count == 0)
            {
                FillPool();
            }

            var instance = _availableObjects.Dequeue();
            instance.SetActive(true);
            return instance;
        }

        private void FillPool()
        {
            for (int i = 0; i < _objectsInPool; i++)
            {
                var objectToAdd = Instantiate(_prefab);
                objectToAdd.transform.SetParent(transform);
                AddToPool(objectToAdd);
            }
        }

        public void AddToPool(GameObject instance)
        {
            instance.SetActive(false);
            _availableObjects.Enqueue(instance);
        }
    }
}
