using Assets.Scripts.Data.NewTypes.DataTypes;

namespace Assets.Scripts.Infrastructure.Services.ProgressService
{
    public interface IPersistentProgressService:IService
    {
       public PlayerProgress PlayerProgress { get; set; }
    }
}