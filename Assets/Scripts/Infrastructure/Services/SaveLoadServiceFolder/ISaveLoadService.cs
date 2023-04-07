using Assets.Scripts.Data.NewTypes.DataTypes;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder
{
    public interface ISaveLoadService : IService
    {
        public PlayerProgress LoadProgress();

        public void SaveProgress();
    }
}