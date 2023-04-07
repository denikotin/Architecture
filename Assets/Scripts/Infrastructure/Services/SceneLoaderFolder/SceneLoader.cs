using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Services.SceneLoaderFolder
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action OnLoaded = null) => _coroutineRunner.StartCoroutine(LoadSceneRoutine(sceneName, OnLoaded));

        private IEnumerator LoadSceneRoutine(string sceneName, Action OnLoaded)
        {
            AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadScene.isDone)
            {
                yield return null;
            }

            OnLoaded?.Invoke();
        }
    }
}
