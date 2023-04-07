using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Button ReloadButton;
    private LevelsPayloads _levelPayloads;
    private IAudioService _audioService;
    private IGameStateMachine _gameStateMachine;

    public void Construct(IGameStateMachine gameStateMachine, LevelsPayloads levelsPayloads, IAudioService audioService)
    {
        _gameStateMachine = gameStateMachine;
        _levelPayloads = levelsPayloads;
        _audioService = audioService;

    }

    public void Awake()
    {
        ReloadButton.onClick.AddListener(ReloadGame);
        ReloadButton.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        _audioService.PlaySound("Buttons");
    }

    private void ReloadGame()
    {
        Continue();
        _gameStateMachine.EnterToState<LoadPlaySceneState,LevelsPayloads>(_levelPayloads);
    }

    private void Continue() => Time.timeScale = 1.0f;
}
