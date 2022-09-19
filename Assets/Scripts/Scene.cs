using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture
{
    public class Scene
    {
        private InteractorsBase _interactorsBase;
        private RepositoriesBase _repositoryBase;
        private SceneConfig _sceneConfig;

        public Scene( SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            _repositoryBase = new RepositoriesBase(_sceneConfig);
            _interactorsBase = new InteractorsBase(_sceneConfig);

        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        public IEnumerator InitializeRoutine()
        {
            _repositoryBase.CreateAllRepositories();
            _interactorsBase.CreateAllInteractors();
            yield return null;

            _repositoryBase.SendOnCreateToAllRepositories();
            _interactorsBase.SendOnCreateToAllInteractors();
            yield return null;

            _repositoryBase.SendInitializeToAllRepositories();
            _interactorsBase.SendInitializeToAllInteractors();
            yield return null;

            _repositoryBase.SendOnStartToAllRepositories();
            _interactorsBase.SendOnStartToAllInteractors();
        }

        public T GetRepository<T>() where T: Repository
        {
            return _repositoryBase.GetRepository<T>();
        }
        public T GetInteractor<T>() where T: Interactor
        {
            return _interactorsBase.GetInteractor<T>();
        }
    }

}


