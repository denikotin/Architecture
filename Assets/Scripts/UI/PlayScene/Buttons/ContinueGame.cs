using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;

namespace Assets.Scripts.UI.PlayScene.Buttons
{
    public class ContinueGame : MonoBehaviour
    {
        public Button Button;
        public Button[] ToolChooseButtons;
        public GameObject PauseMenu;
        private IAudioService _audioService;

        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private void Start()
        {
            Button.onClick.AddListener(ClosePauseMenu);
            Button.onClick.AddListener(Continue);
            Button.onClick.AddListener(PlayButtonSound);
            Button.onClick.AddListener(StartWalking);
            Button.onClick.AddListener(SwitchOnToolButtons);
        }


        private void SwitchOnToolButtons()
        {
            foreach (Button button in ToolChooseButtons)
            {
                button.enabled = true;
            }
        }

        private void StartWalking()
        {
            _audioService.PlaySound("Walking");
        }

        private void PlayButtonSound()
        {
            _audioService.PlaySound("Buttons");
        }

        private void ClosePauseMenu() => PauseMenu.SetActive(false);

        private void Continue() => Time.timeScale = 1.0f;
    }
}

