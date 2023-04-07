using UnityEngine;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;

namespace Assets.Scripts.Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private GameStaticData _gameStaticData;

        public void Load()
        {
            _gameStaticData = Resources.Load<GameStaticData>(AssetsPaths.GAME);
        }

        public GameStaticData GetGameStaticData() => _gameStaticData;

    }
}
