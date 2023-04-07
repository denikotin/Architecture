namespace Assets.Scripts.Infrastructure.Services.AudioServiceFolder
{
    public interface IAudioService:IService
    {
        public void Initialize();
        public void PlaySound(string name);
        public void PauseSound(string name);
        public void StopSound(string name);
        public void SetAudioVolume(AudioVolume volume);
        public void SetAudioManager(AudioManager audioManager);
        public void ChangeMusicVolume(float value);
        public void ChangeSoundVolume (float value);
    }
}
