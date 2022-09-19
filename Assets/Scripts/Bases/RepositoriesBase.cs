using System;
using System.Collections.Generic;

namespace Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> _repositoriesMap;
        private SceneConfig _sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            _repositoriesMap = _sceneConfig.CreateAllRepository();
        }

        public void SendOnCreateToAllRepositories()
        {
            foreach (var repository in _repositoriesMap.Values)
            {
                repository.OnCreate();
            }
        }

        public void SendInitializeToAllRepositories()
        {
            foreach (var repository in _repositoriesMap.Values)
            {
                repository.Initialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            foreach (var repository in _repositoriesMap.Values)
            {
                repository.OnStart();
            }
        }

        public T GetRepository<T>() where T: Repository
        {
            var type = typeof(T);
            return (T) _repositoriesMap[type];
        }
    }
}
