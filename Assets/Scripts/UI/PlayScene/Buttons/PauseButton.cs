using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI.PlayScene.Buttons
{
    public class PauseButton : MonoBehaviour
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
            Button.onClick.AddListener(ShowPauseMenu);
            Button.onClick.AddListener(StopGame);
            Button.onClick.AddListener(PlayButtonSound);
            Button.onClick.AddListener(StopWalking);
            Button.onClick.AddListener(SwitchOffToolButtons);
            PauseMenu.SetActive(false);
        }


        private void SwitchOffToolButtons()
        {
            foreach(Button button in ToolChooseButtons)
            {
                button.enabled = false;
            }
        }

        private void PlayButtonSound()
        {
            _audioService.PlaySound("Buttons");
        }

        private void StopWalking()
        {
            _audioService.StopSound("Walking");
        }

        private void ShowPauseMenu() => PauseMenu.SetActive(true);

        private void StopGame()
        {
            Time.timeScale = 0;
        }
    }
}

