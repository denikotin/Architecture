using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        private ServiceLocator _serviceLocator;
        private IGameStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        public Game(ICoroutineRunner coroutineRunner, GameObject loadingCurtain)
        {
            _serviceLocator = new ServiceLocator();
            _sceneLoader = new SceneLoader(coroutineRunner);
            _stateMachine = new GameStateMachine(_serviceLocator, _sceneLoader, loadingCurtain);
        }

        public void Run()
        {
            SetGameSettings();
            _stateMachine.EnterToState<BootstrapState>();
        }

        private void SetGameSettings()
        {
            Application.targetFrameRate = 90;
            QualitySettings.vSyncCount = 0;
        }
    }
}
