using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Common
{
    public class LoadingCurtains : MonoBehaviour
    {
        public Image Pickaxe;
        private void Awake() => DontDestroyOnLoad(gameObject);

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void Update()
        {
            Pickaxe.transform.Rotate( Vector3.back * Time.deltaTime * 100);
        }
    }
}

