using Assets.Scripts.Data.Enums;

namespace Assets.Scripts.Infrastructure.Services.WindowService
{
    public interface IWindowService: IService
    {
        void Open(WindowID windowID);
    }
}