using Assets.Scripts.Infrastructure.Services.StaticDataService;
using System;

namespace Assets.Scripts.Data.NewTypes.DataTypes
{
    [Serializable]
    public class PlayerProgress
    {
        public AudioData AudioData;
        public bool IsFirstStart;

        public event Action OnFirstStartChanged; 

        public PlayerProgress(IStaticDataService staticData) 
        {
            AudioData = new AudioData();
            IsFirstStart = true;
        }

        public void SetFirstStart()
        {
            IsFirstStart = false;
            OnFirstStartChanged?.Invoke();
        }
    }
}
