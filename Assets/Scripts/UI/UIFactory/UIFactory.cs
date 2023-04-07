using UnityEngine;
using Assets.Scripts.UI.MainScene;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.UI.PlayScene.Buttons;
using Assets.Scripts.UI.Common.WindowsLogic;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;


namespace Assets.Scripts.UI.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private Transform _root;
        private readonly IAssetProvider _assetProvider;
        private readonly ServiceLocator _serviceLocator;
        private readonly IPersistentProgressService _progressService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IAudioService _audioService;

        public UIFactory(IAssetProvider assetProvider, ServiceLocator serviceLocator)
        {
            _assetProvider = assetProvider;
            _serviceLocator = serviceLocator;  
            _progressService = _serviceLocator.GetService<IPersistentProgressService>();
            _gameStateMachine = _serviceLocator.GetService<IGameStateMachine>();
            _staticDataService = _serviceLocator.GetService<IStaticDataService>();
            _saveLoadService = _serviceLocator.GetService<ISaveLoadService>(); 
            _audioService = _serviceLocator.GetService<IAudioService>();
            
        }
        public GameObject CreateHUD()
        {
            GameObject hudPrefab = _assetProvider.Load(AssetsPaths.HUD);
            GameObject hud = Object.Instantiate(hudPrefab, _root);
            ConstructPauseMenu(hud);
            return hud;
        }



        public GameObject CreateMainMenu()
        {
            GameObject mainMenuPrefab = _assetProvider.Load(AssetsPaths.MAINMENU);
            GameObject mainMenu = Object.Instantiate(mainMenuPrefab, _root);
            return mainMenu;
        }




        public GameObject CreateRootUI()
        {
            GameObject rootPrefab = _assetProvider.Load(AssetsPaths.UIROOT); 
            GameObject root = Object.Instantiate(rootPrefab);
            _root = root.transform;
            return root;
        }

        public GameObject CreateInventoryMenu()
        {
            GameObject inventoryMenu = _assetProvider.Load(AssetsPaths.INVENTORY);
            GameObject inventory = Object.Instantiate(inventoryMenu, _root);
            inventory.GetComponent<InventoryBase>().Construct(_saveLoadService, _audioService);
            return inventory;
        }

        public GameObject CreateGuideMenu()
        {
            GameObject guideMenu = _assetProvider.Load(AssetsPaths.GUIDE);
            GameObject guide = Object.Instantiate(guideMenu, _root);
            guide.GetComponent<GuideBase>().Construct(_saveLoadService, _audioService);
            guide.GetComponentInChildren<PagesTurnOver>().Construct(_audioService);
            _progressService.PlayerProgress.SetFirstStart();
            return guideMenu;
        }

        public GameObject CreateInfoMenu()
        {
            GameObject infoMenu = _assetProvider.Load(AssetsPaths.INFO);
            GameObject info = Object.Instantiate(infoMenu, _root);
            info.GetComponent<InfoBase>().Construct(_saveLoadService, _audioService);
            return info;
        }

        public GameObject CreateSettingsMenu()
        {
            GameObject settingsMenu = _assetProvider.Load(AssetsPaths.SETTINGS);
            GameObject settings = Object.Instantiate(settingsMenu, _root);
            settings.GetComponent<SettingsBase>().Construct(_saveLoadService,_audioService);
            settings.GetComponentInChildren<AudioSliders>().Construct(_progressService, _serviceLocator.GetService<IAudioService>());
            return settings;
        }




        private void ConstructPauseMenu(GameObject hud)
        {
            MainMenuButton[] mainMenuButtons = hud.GetComponentsInChildren<MainMenuButton>();
            foreach (MainMenuButton button in mainMenuButtons)
            {
                button.Construct(_gameStateMachine,
                                 _saveLoadService,
                                 _audioService);
            }
            
        }

        private void ConstructReloadButtons()
        {

        }
    }
}
