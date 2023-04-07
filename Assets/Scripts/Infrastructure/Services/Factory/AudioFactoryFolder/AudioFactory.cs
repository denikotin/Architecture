using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory
{
    public class AudioFactory : IAudioFactory
    {
        private IAssetProvider _assetsProvider;

        public AudioFactory(ServiceLocator serviceLocator)
        {
            _assetsProvider = serviceLocator.GetService<IAssetProvider>();
        }

        public GameObject CreateMainMenuAudioManager()
        {
            GameObject audioManagerPrefab = _assetsProvider.Load(AssetsPaths.MAIN_MENU_AUDIO_MANAGER);
            GameObject audioManager = Object.Instantiate(audioManagerPrefab);
            return audioManager;
        }

        public GameObject CreatePlayAudioManager()
        {
            GameObject audioManagerPrefab = _assetsProvider.Load(AssetsPaths.PLAY_AUDIO_MANAGER);
            GameObject audioManager = Object.Instantiate(audioManagerPrefab);
            return audioManager;
        }

    }
}
