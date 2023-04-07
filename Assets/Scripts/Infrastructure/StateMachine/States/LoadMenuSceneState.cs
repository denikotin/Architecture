using UnityEngine;
using Assets.Scripts.UI.Elements;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services.WindowService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.UI.Common;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using System;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.Factory;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadMenuSceneState : IPayloadState<LevelsPayloads>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ServiceLocator _serviceLocator;
        
        private IUIFactory _uIFactory;
        private ISceneLoader _sceneLoader;
        private IAudioService _audioService;
        private IAudioFactory _audioFactory;
        private IWindowService _windowService;
        private LoadingCurtains _loadingCurtain;
        private IPersistentProgressService _progressService;

        public LoadMenuSceneState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, GameObject loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _loadingCurtain = loadingCurtain.GetComponent<LoadingCurtains>();
        }

        public void Enter(LevelsPayloads levelsPayloads )
        {
            Debug.Log($"Entered {this.GetType().Name}");
            _loadingCurtain.Show();
            GetServices();
            LoadScene(levelsPayloads);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
            Yandex.instance.ShowAdv();
        }


        private void LoadScene(LevelsPayloads payloads)
        {
            if (payloads.SceneName == "Main")
                _sceneLoader.Load(payloads.SceneName, OnLoadedMain);
        }

        private void OnLoadedMain()
        {
            ConstructSound();
            ConstructUI();
            _gameStateMachine.EnterToState<GameLoopState>();
        }

       
        private void GetServices()
        {
            _uIFactory = _serviceLocator.GetService<IUIFactory>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _windowService = _serviceLocator.GetService<IWindowService>();
            _progressService = _serviceLocator.GetService<IPersistentProgressService>();
            _audioService = _serviceLocator.GetService<IAudioService>();
            _audioFactory = _serviceLocator.GetService<IAudioFactory>();

        }

        private void ConstructSound()
        {
            AudioManager audioManager = _audioFactory.CreateMainMenuAudioManager().GetComponent<AudioManager>();
            _audioService.SetAudioManager(audioManager);
        }

        private void ConstructUI()
        {
            ConstructUIRoot();
            ConstructMainMenu(_progressService);
     
        }

        private void ConstructUIRoot() => _uIFactory.CreateRootUI();

        private void ConstructMainMenu(IPersistentProgressService progressService)
        {
            GameObject mainMenu = _uIFactory.CreateMainMenu();
            foreach (OpenWindowButton windowButton in mainMenu.GetComponentsInChildren<OpenWindowButton>())
            {
                windowButton.Construct(_windowService, _audioService);
            }
        }
    }
}
