using UnityEngine;
using UnityEngine.UI;

public class ShowAnotherGames : MonoBehaviour
{
    public Button Button;

    void Start()
    {
        Button.onClick.AddListener(OpenDeveloperSite);
    }

    private void OpenDeveloperSite()
    {
        Application.OpenURL($"https://yandex.{Yandex.instance.Domain}/games/developer?name=nikotinStudio");  
    }
}
