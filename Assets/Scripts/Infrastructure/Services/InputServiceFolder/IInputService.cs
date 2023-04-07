using System;

namespace Assets.Scripts.Infrastructure.Services.InputServiceFolder
{
    public interface IInputService: IService
    {
        public event Action<bool[]> OnSwipeEvent;
        public event Action OnClickEvent;
        void UpdateSwipeService();

        public float GetAxis();
    }
}