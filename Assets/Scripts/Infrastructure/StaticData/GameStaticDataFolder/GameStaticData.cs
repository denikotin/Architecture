using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder
{
    [CreateAssetMenu(fileName = "GameData", menuName = "StaticData/Game")]
    public class GameStaticData:ScriptableObject
    {
        public int LevelCount;
    }
}
