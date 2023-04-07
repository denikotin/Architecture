using Assets.Scripts.Infrastructure.Services.ProgressService;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolume : MonoBehaviour
{
    public AudioMixerGroup Master;
    private IPersistentProgressService _progressService; 

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Construct(IPersistentProgressService progressService)
    {
        _progressService = progressService;
    }

    private void Start()
    {
        SetStartVolumeLevel();
    }

    private void SetStartVolumeLevel()
    {
        Master.audioMixer.SetFloat("Music", Mathf.Lerp(-60, 0, _progressService.PlayerProgress.AudioData.Music));
        Master.audioMixer.SetFloat("Sound", Mathf.Lerp(-60, 0, _progressService.PlayerProgress.AudioData.Sound));
    }

    public void ChangeMusicVolume(float value)
    {
        Master.audioMixer.SetFloat("Music", Mathf.Lerp(-60, 0, value));
    }

    public void ChangeSoundVolume(float value)
    {
        Master.audioMixer.SetFloat("Sound", Mathf.Lerp(-60, 0, value));
    }


}
