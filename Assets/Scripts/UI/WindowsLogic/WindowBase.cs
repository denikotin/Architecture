using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder;

namespace Assets.Scripts.UI.WindowsLogic
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;
        protected ISaveLoadService _saveLoadService;
        protected IAudioService _audioService;

        public virtual void Construct(ISaveLoadService saveLoadService, IAudioService audioService)
        {
            _saveLoadService = saveLoadService;
            _audioService = audioService;
        }

        public void Awake() => OnAwake();

        public void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => DescribeUpdates();

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(() => _saveLoadService.SaveProgress());
            CloseButton.onClick.AddListener(() => Destroy(gameObject));
            CloseButton.onClick.AddListener(() => _audioService.PlaySound("ButtonSound"));
            CloseButton.onClick.AddListener(Yandex.instance.ShowAdv);
        }

        protected virtual void Initialize() { }
    
        protected virtual void SubscribeUpdates() { }

        protected virtual void DescribeUpdates() { }
    }
}