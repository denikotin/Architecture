using Assets.Scripts.Infrastructure.Services.ProgressService;

namespace Assets.Scripts.Infrastructure.Services.AudioServiceFolder
{
    public class AudioService: IAudioService
    {
        private AudioVolume _audioVolume;
        private AudioManager _audioManager;
        private IPersistentProgressService _progressService;

        public AudioService(IPersistentProgressService progressService) 
        {
            _progressService = progressService;
        }

        public void Initialize()
        {
            Yandex.instance.OnAdvOpenEvent += () => StopSound("Music");
            Yandex.instance.OnAdvCloseEvent += () => PlaySound("Music");
            Yandex.instance.OnRewardedCloseEvent += () => PlaySound("Music");
        }

        
        public void SetAudioVolume(AudioVolume volume) => _audioVolume = volume;

        public void SetAudioManager(AudioManager audioManager) => _audioManager = audioManager;

        public void PlaySound(string name) => _audioManager.PlaySound(name);

        public void ChangeMusicVolume(float value)
        {
            _audioVolume.ChangeMusicVolume(value);
            _progressService.PlayerProgress.AudioData.Music = value;
        }

        public void ChangeSoundVolume(float value)
        {
            _audioVolume.ChangeSoundVolume(value);
            _progressService.PlayerProgress.AudioData.Sound = value;
        }

        public void PauseSound(string name) => _audioManager.PauseSound(name);

        public void StopSound(string name) => _audioManager.StopSound(name);
    }
}
