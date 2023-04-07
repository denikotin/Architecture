using UnityEngine;

public class CurrentTool : MonoBehaviour
{
    public GameObject StartTool;
    private GameObject _currentTool;

    private void Start()
    {
        _currentTool = StartTool;
        _currentTool.SetActive(true);
    }
    public void SwitchTool(GameObject toolFrame)
    {
        if(_currentTool != null) 
        {
            _currentTool.SetActive(false);
        }
        _currentTool = toolFrame;
        _currentTool.SetActive(true);
    }
}
