using Assets.Scripts.Data.DataExtensionFolder;
using Assets.Scripts.Data.NewTypes.DataTypes;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder
{
    public class SaveLoadService: ISaveLoadService
    {
        private const string PROGRESS = "Progress";
        private IPersistentProgressService _progressService;


        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }
        
        public PlayerProgress LoadProgress()
        {
            //Debug.Log(Yandex.instance.Load());
            //return Yandex.instance.Load().ToDeserialized<PlayerProgress>();
            return PlayerPrefs.GetString(PROGRESS).ToDeserialized<PlayerProgress>();
        }

        public void SaveProgress()
        {
            //Yandex.instance.Save(_progressService.PlayerProgress.ToJsong());
            PlayerPrefs.SetString(PROGRESS, _progressService.PlayerProgress.ToJsong());
        }
    }
}
