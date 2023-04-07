using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.PoolService
{
    public class Pool
    {
        private List<GameObject> _container = new List<GameObject>();

        public List<GameObject> Container { get { return _container; } }

        public void Add(GameObject gameObject) => _container.Add(gameObject);

        public void Set(List<GameObject> objectList) => _container = objectList;
    }
}
