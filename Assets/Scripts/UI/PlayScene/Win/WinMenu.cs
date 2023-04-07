using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuObject;
    public GameObject[] OtherHUD;


    public void Construct() { }

    private void Start()
    {
        WinMenuObject.SetActive(false);
    }

    private void OnDisable()
    {
    }

    private void ShowWinMenu() => WinMenuObject.SetActive(true);
    private void HideOtherHUD()
    {
        foreach(GameObject hud in OtherHUD)
        {
            hud.SetActive(false);
        }
    }


}
