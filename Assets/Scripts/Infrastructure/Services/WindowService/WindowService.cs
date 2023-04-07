using Assets.Scripts.Data.Enums;
using Assets.Scripts.UI.UIFactory;

namespace Assets.Scripts.Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uIFactory)
        {
            _uiFactory = uIFactory;
        }

        public void Open(WindowID windowID)
        {
            switch (windowID)
            {
                case WindowID.Unknown:
                    break;
                case WindowID.Inventory:
                    _uiFactory.CreateInventoryMenu();
                    break;
                case WindowID.Guide:
                    _uiFactory.CreateGuideMenu();
                    break;
                case WindowID.Info:
                    _uiFactory.CreateInfoMenu();
                    break;
                case WindowID.Settings:
                    _uiFactory.CreateSettingsMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
