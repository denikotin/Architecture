using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.StateMachine.States;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;


namespace Assets.Scripts.UI.PlayScene.Buttons
{
    public class MainMenuButton : MonoBehaviour
    {
        public Button MenuButton;
        private IGameStateMachine _gameStateMachine;
        private ISaveLoadService _saveLoadService;
        private IAudioService _audioService;

        public void Construct(IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService, IAudioService audioService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _audioService = audioService;
        }

        public void Start()
        {
            MenuButton.onClick.AddListener(Continue);
            MenuButton.onClick.AddListener(LoadMainMenu);
            MenuButton.onClick.AddListener(PlayButtonSound);
        }

        private void PlayButtonSound()
        {
            _audioService.PlaySound("Buttons");
        }

        private void LoadMainMenu()
        {
            LevelsPayloads levelsPayloads = CreatePayloadsForMainScene();
            _gameStateMachine.EnterToState<LoadMenuSceneState, LevelsPayloads>(levelsPayloads);
        }

        private LevelsPayloads CreatePayloadsForMainScene()
        {
            LevelsPayloads levelsPayloads = new LevelsPayloads();
            levelsPayloads.SceneName = "Main";
            return levelsPayloads;
        }

        private void Continue() 
        {
            Time.timeScale = 1f;
        }
    }
}

