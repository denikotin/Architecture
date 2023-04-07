using Assets.Scripts.Data.NewTypes.DataTypes;

namespace Assets.Scripts.Infrastructure.Services.ProgressService
{
    public class PersistentProgressService: IPersistentProgressService
    {
       public PlayerProgress PlayerProgress { get; set; }
    }
}
