using UnityEngine;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Data.NewTypes.DataTypes;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly IGameStateMachine _gameStateMachine;

        private ISaveLoadService _saveLoadService;
        private IStaticDataService _staticDataService;
        private IPersistentProgressService _persistentProgress;
        private IAudioService _audioService;
        public LoadProgressState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
        }

        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");

            LevelsPayloads levelsPayloads = CreatePayloadsForMainScene();

            GetServices();
            Load();
            SetSoundLevel();
            _gameStateMachine.EnterToState<LoadMenuSceneState, LevelsPayloads>(levelsPayloads);
        }

        private void SetSoundLevel()
        {
            GameObject mixer = Object.Instantiate(_serviceLocator.GetService<IAssetProvider>().Load(AssetsPaths.AUDIO_MIXER));
            AudioVolume audioVolume = mixer.GetComponent<AudioVolume>();
            audioVolume.Construct(_persistentProgress);
            _audioService.SetAudioVolume(audioVolume);
        }

        private void GetServices()
        {
            _staticDataService = _serviceLocator.GetService<IStaticDataService>();
            _persistentProgress = _serviceLocator.GetService<IPersistentProgressService>();
            _saveLoadService = _serviceLocator.GetService<ISaveLoadService>();
            _audioService = _serviceLocator.GetService<IAudioService>();
        }

        public void Exit()
        {

        }

        private LevelsPayloads CreatePayloadsForMainScene()
        {
            LevelsPayloads levelsPayloads = new LevelsPayloads();
            levelsPayloads.SceneName = "Main";
            return levelsPayloads;
        }

        private void Load()
        {
            LoadStaticData();
            LoadProgressOrInitNew();
        }

        private void LoadStaticData() => _staticDataService.Load();

        private void LoadProgressOrInitNew()
        {
            _persistentProgress.PlayerProgress = _saveLoadService.LoadProgress();
            if (_persistentProgress.PlayerProgress == null)
            {
                _persistentProgress.PlayerProgress = NewProgress();
            }
        }

        private PlayerProgress NewProgress()
        {
            PlayerProgress progress = new PlayerProgress(_staticDataService);
            return progress;

        }
    }
}
