using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrap : MonoBehaviour, ICoroutineRunner
    {
        public GameObject LoadCurtain;
        public Yandex Yandex;
        private Game _game;

        private void Awake()
        {
            Instantiate(Yandex);
            _game = new Game(this,Instantiate(LoadCurtain));
            _game.Run();

            DontDestroyOnLoad(gameObject);
        }
    }
}
