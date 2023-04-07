using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.PoolService
{
    public interface IObjectPoolService:IService
    {
        public Pool CreatePool(string poolName);
        public void SetPool(string poolName, GameObject gameObject);
        public void SetPool(string poolName, List<GameObject> objectList);
        public Pool GetPool(string poolName);
        public void RemovePool(string poolName);
        public void CleanUp();

    }
}