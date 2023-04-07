using System;

namespace Assets.Scripts.Infrastructure.Services.SceneLoaderFolder
{
    public interface ISceneLoader : IService
    {
        public void Load(string sceneName, Action OnLoaded = null);
    }
}