using TMPro;
using UnityEngine;

public class FailMenu : MonoBehaviour
{
    public GameObject FailMenuObject;
    public TextMeshProUGUI FailText;



    public void Construct() { }

    private void Start()
    {
        FailMenuObject.SetActive(false);
    }


    private void UpdateFailText(string reason)
    {
        FailMenuObject.SetActive(true);
        FailText.text = reason;
    }
}
