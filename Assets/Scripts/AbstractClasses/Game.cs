using System;
using System.Collections;
using UnityEditor.Callbacks;

namespace Architecture
{
    public static class Game
    {
        public static event Action OnGameInitializeEvent;
        public static SceneManagerBase SceneManager { get; private set; }
        public static void Run()
        {
            SceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            SceneManager.InitScenesMap();
            yield return SceneManager.LoadCurrentSceneAsync();
            OnGameInitializeEvent?.Invoke();
        }

        public static T GetRepository<T>() where T: Repository
        {
            return  SceneManager.GetRepository<T>();
        }
        public static T GetInteractor<T>() where T : Interactor
        {
            return SceneManager.GetInteractor<T>();
        }
    }
}
