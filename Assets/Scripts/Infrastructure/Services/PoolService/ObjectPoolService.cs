using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Services.PoolService
{
    public class ObjectPoolService : IObjectPoolService
    {
        private Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();
        public Pool CreatePool(string poolName)
        {
            Pool pool = new Pool();
            _pools.Add(poolName, pool);
            return pool;
        }

        public void SetPool(string poolName, GameObject gameObject) => _pools[poolName].Add(gameObject);
        public void SetPool(string poolName, List<GameObject> objectList) => _pools[poolName].Set(objectList);

        public Pool GetPool(string poolName) => _pools[poolName];

        public void RemovePool(string poolName) => _pools.Remove(poolName);

        public void CleanUp() => _pools.Clear();

    }
}

