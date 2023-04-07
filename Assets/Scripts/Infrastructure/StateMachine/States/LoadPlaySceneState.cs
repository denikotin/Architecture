using UnityEngine;
using Assets.Scripts.UI.Common;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services.Factory;
using Assets.Scripts.Infrastructure.Services.PoolService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadPlaySceneState : IPayloadState<LevelsPayloads>
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly LoadingCurtains _loadingCurtain;
        private readonly IGameStateMachine _gameStateMachine;

        private LevelsPayloads _levelsPayloads;

        private IUIFactory _uiFactory;
        private ISceneLoader _sceneLoader;
        private IAudioService _audioService;
        private IAudioFactory _audioFactory;
        private IObjectPoolService _objectPool;
        private IStaticDataService _staticDataService;
        private IPersistentProgressService _persistentProgressService;

        public LoadPlaySceneState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, GameObject loadingCurtain) 
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _loadingCurtain = loadingCurtain.GetComponent<LoadingCurtains>();
        }

        public void Enter(LevelsPayloads payloads)
        {
            Debug.Log($"Entered {this.GetType().Name}");
            _levelsPayloads = payloads;
            _loadingCurtain.Show();
            GetServices();
            LoadScene(_levelsPayloads);
        }

        public void Exit() => _loadingCurtain.Hide();

        private void GetServices()
        {
            _uiFactory = _serviceLocator.GetService<IUIFactory>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _audioService = _serviceLocator.GetService<IAudioService>();
            _audioFactory = _serviceLocator.GetService<IAudioFactory>();
            _objectPool = _serviceLocator.GetService<IObjectPoolService>();
            _staticDataService = _serviceLocator.GetService<IStaticDataService>();
            _persistentProgressService = _serviceLocator.GetService<IPersistentProgressService>();
        }

        private void LoadScene(LevelsPayloads levelsPayloads) => _sceneLoader.Load(levelsPayloads.SceneName, OnLoaded);

        private void OnLoaded()
        {
            ConstructSound();
            ConstructPlayScene();
            _gameStateMachine.EnterToState<GameLoopState>();
        }

        private void ConstructSound()
        {
            AudioManager audioManager = _audioFactory.CreatePlayAudioManager().GetComponent<AudioManager>();
            _audioService.SetAudioManager(audioManager);
        }

        private void ConstructPlayScene()
        {
            _objectPool.CleanUp();
            GameObject hud = ConstructHUD();
        }


        #region UI
        private GameObject ConstructHUD()
        {
            ConstructUIRoot();
            GameObject _hud = _uiFactory.CreateHUD();
            return _hud;
        }

        private void ConstructUIRoot()
        {
           _uiFactory.CreateRootUI();
        }


        #endregion



    }
}
