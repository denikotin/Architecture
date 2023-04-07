using Assets.Scripts.Infrastructure.Services.SwipeServiceFolder;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputServiceFolder
{
    public class InputService : IInputService
    {
        private readonly SwipeService _swipeService;

        public event Action<bool[]> OnSwipeEvent;
        public event Action OnClickEvent;


        public InputService()
        {
            _swipeService = new SwipeService();
            _swipeService.OnSwipeEvent += InvokeSwipeEvent;
            _swipeService.OnClickEvent += InvokeClickEvent;
        }

        public void UpdateSwipeService() => _swipeService.UpdateSwipeManager();

        public float GetAxis()
        {
            float direction = 0;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow))
            {
                direction = 1;
            }
            return direction;
        }

        private void InvokeSwipeEvent(bool[] swipes) => OnSwipeEvent?.Invoke(swipes);
        private void InvokeClickEvent() => OnClickEvent?.Invoke();

    }
}
