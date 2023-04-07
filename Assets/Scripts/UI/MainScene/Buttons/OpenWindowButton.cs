using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Infrastructure.Services.WindowService;
using Assets.Scripts.Data.Enums;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;

namespace Assets.Scripts.UI.Elements
{
    public class OpenWindowButton : MonoBehaviour
    {
        public Button Button;
        public WindowID windowID;
        private IWindowService _windowService;
        private IAudioService _audioService;

        public void Construct(IWindowService windowService, IAudioService audioService)
        {
            _windowService = windowService;
            _audioService = audioService;
        }

        public void Awake() => Button.onClick.AddListener(Open);

        private void Open()
        {
            _windowService.Open(windowID);
            _audioService.PlaySound("ButtonSound");
        }
    }
}