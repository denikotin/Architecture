using UnityEngine;
using Assets.Scripts.Infrastructure.Services;


namespace Assets.Scripts.UI.UIFactory
{
    public interface IUIFactory : IService
    {
        GameObject CreateRootUI();
        GameObject CreateHUD();
        GameObject CreateGuideMenu();
        GameObject CreateMainMenu();
        GameObject CreateInventoryMenu();
        GameObject CreateSettingsMenu();
        GameObject CreateInfoMenu();
    }
}