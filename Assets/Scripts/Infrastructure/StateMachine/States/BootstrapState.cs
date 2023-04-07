using UnityEngine;
using GameAnalyticsSDK;
using Assets.SimpleLocalization;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.Services.Factory;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.Services.PoolService;
using Assets.Scripts.Infrastructure.Services.WindowService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.InputServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;
        

        public BootstrapState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");
            RegisterServices();
            InitializeServices();
            InitializeLanguage();
            _gameStateMachine.EnterToState<LoadProgressState>();
        }

        public void Exit()
        {
       
        }

        public void RegisterServices()
        { 
            _serviceLocator.RegisterService<ISceneLoader>(_sceneLoader);
            _serviceLocator.RegisterService<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterService<IPersistentProgressService>( new PersistentProgressService());
            _serviceLocator.RegisterService<ISaveLoadService>(new SaveLoadService(_serviceLocator.GetService<IPersistentProgressService>()));
            _serviceLocator.RegisterService<IStaticDataService>(new StaticDataService());
            _serviceLocator.RegisterService<IObjectPoolService>(new ObjectPoolService());
            _serviceLocator.RegisterService<IAssetProvider>(new AssetProvider());
            _serviceLocator.RegisterService<IAudioService>(new AudioService(_serviceLocator.GetService<IPersistentProgressService>()));
            _serviceLocator.RegisterService<IUIFactory>(new UIFactory(_serviceLocator.GetService<IAssetProvider>(), _serviceLocator));
            _serviceLocator.RegisterService<IWindowService>(new WindowService(_serviceLocator.GetService<IUIFactory>()));
            _serviceLocator.RegisterService<IInputService>(new InputService());
            _serviceLocator.RegisterService<IAudioFactory>(new AudioFactory(_serviceLocator));
        }

        private void InitializeServices()
        {
            _serviceLocator.GetService<IAudioService>().Initialize();
            GameAnalytics.Initialize();
        }

        private void InitializeLanguage()
        {
            Yandex.instance.GetLanguage();
            Yandex.instance.GetDomain();

            LocalizationManager.Read();
            Debug.Log(Yandex.instance.Language);
            Debug.Log(Yandex.instance.Domain);
            switch (Yandex.instance.Language)
            {
                case "ru":
                    LocalizationManager.Language = "Russian";
                    break;
                case "en":
                    LocalizationManager.Language = "English";
                    break;
                case "tr":
                    LocalizationManager.Language = "Turkish";
                    break;
                case "es":
                    LocalizationManager.Language = "Spanish";
                    break;
            }
        }
    }
}
