using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MainScene
{
    public class AudioSliders:MonoBehaviour
    {
        public Slider SoundSlider;
        public Slider MusicSlider;
        private IPersistentProgressService _progressService;
        private IAudioService _audioService;


        public void Construct(IPersistentProgressService progressService, IAudioService audioService)
        {
            _progressService = progressService;
            _audioService = audioService;
        }

        private void Start()
        {
            SoundSlider.value = _progressService.PlayerProgress.AudioData.Sound;
            MusicSlider.value = _progressService.PlayerProgress.AudioData.Music;
            SoundSlider.onValueChanged.AddListener(ChangeSoundLevel);
            MusicSlider.onValueChanged.AddListener(ChangeMusicLevel);
        }

        private void OnDestroy()
        {
            SoundSlider.onValueChanged.RemoveListener(ChangeSoundLevel);
            MusicSlider.onValueChanged.RemoveListener(ChangeMusicLevel);
        }

        public void ChangeSoundLevel(float value)
        {
            _audioService.ChangeSoundVolume(value);
        }

        public void ChangeMusicLevel(float value)
        {
            _audioService.ChangeMusicVolume(value);
        }

    }

}
