using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SwipeServiceFolder
{
    public class SwipeService
    {
        private const float SWIPE_THRESHOLD = 50f;

        public enum Directions { Left, Right, Up, Down};
        private Vector2 _startTouch;
        private Vector2 _swipeDelta;

        private bool _touchMoved;
        private bool[] _swipe = new bool[4];

        public event Action OnClickEvent;
        public event Action<bool[]> OnSwipeEvent;

        public void UpdateSwipeManager()
        {
               
            if (TouchBegan())
            {
                _startTouch = TouchPosition();
                _touchMoved = true;
            }
            else if (TouchEnded() && _touchMoved)
            {
                SendSwipe();
                _touchMoved = false;
            }

            _swipeDelta = Vector2.zero;
            if (_touchMoved && GetTouch())
            {
                _swipeDelta = TouchPosition() - _startTouch;
            }

            if (_swipeDelta.magnitude > SWIPE_THRESHOLD)
            {
                if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                {
                    _swipe[(int)Directions.Left] = _swipeDelta.x < 0;
                    _swipe[(int)Directions.Right] = _swipeDelta.x > 0;
                }
                else
                {
                    _swipe[(int)Directions.Down] = _swipeDelta.y < 0;
                    _swipe[(int)Directions.Up] = _swipeDelta.y > 0;
                }
                SendSwipe();
            }
        }


        private void SendSwipe()
        {
            if (_swipe[0] || _swipe[1] || _swipe[2] || _swipe[3])
            {
                OnSwipeEvent?.Invoke(_swipe);
            }
            else
            {
                OnClickEvent?.Invoke();
            }
            Reset();
            
        }
        private void Reset()
        {
            _startTouch = Vector2.zero;
            _swipeDelta = Vector2.zero;
            _touchMoved = false;
            for(int i = 0; i < _swipe.Length; i++)
            {
                _swipe[i] = false;
            }
        }
        private Vector2 TouchPosition() => (Vector2)Input.mousePosition;
        private bool TouchEnded() => Input.GetMouseButtonUp(0);
        private bool TouchBegan() => Input.GetMouseButtonDown(0);
        private bool GetTouch() => Input.GetMouseButton(0);
    }
}
