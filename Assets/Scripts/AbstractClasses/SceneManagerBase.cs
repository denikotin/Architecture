using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public abstract class SceneManagerBase
    {
        public Scene Scene { get; private set; }
        public bool isLoading { get; private set; }
        public event Action<Scene> OnSceneLoadEvent;

        protected Dictionary<string, SceneConfig> sceneConfigMap;

        public SceneManagerBase()
        {
            sceneConfigMap = new Dictionary<string, SceneConfig>();
        }

        public abstract void InitScenesMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (isLoading)
            {
                throw new Exception("Scene is loading now");
            }
            var sceneName = SceneManager.GetActiveScene().name;
            var sceneConfig = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(sceneConfig));

        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;

            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

            isLoading = false;
            OnSceneLoadEvent?.Invoke(Scene);
        }


        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if(isLoading)
            {
                throw new Exception("Scene is loading now");
            }

            var sceneConfig = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(sceneConfig));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;

            yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

            isLoading = false;
            OnSceneLoadEvent?.Invoke(Scene);
        }


        private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
            async.allowSceneActivation = false;
            
            while(async.progress < 0.9f)
            {
                yield return null;
            }
            async.allowSceneActivation = true;
        } 

        private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
        {
            Scene = new Scene(sceneConfig);
            yield return Scene.InitializeAsync();
        }

        public T GetRepository<T>() where T: Repository
        {
            return Scene.GetRepository<T>();
        }
        public T GetInteractor<T>() where T : Interactor
        {
            return Scene.GetInteractor<T>();
        }
    }
}
