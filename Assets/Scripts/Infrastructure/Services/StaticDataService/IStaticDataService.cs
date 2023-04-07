using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;

namespace Assets.Scripts.Infrastructure.Services.StaticDataService
{
    public interface IStaticDataService:IService
    {
        public GameStaticData GetGameStaticData();
        public void Load();
    }
}