using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory
{
    public interface IAudioFactory:IService
    {
        GameObject CreateMainMenuAudioManager();
        GameObject CreatePlayAudioManager();
    }
}