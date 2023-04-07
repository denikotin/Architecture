using Assets.Scripts.Infrastructure.Services.AudioServiceFolder;
using UnityEngine;
using UnityEngine.UI;

public class PagesTurnOver : MonoBehaviour
{

    public Button NextPageButton;
    public Button PreviousPageButton;
    public GameObject[] Pages;

    private GameObject _currentPage;
    private int _pageIndex;
    private IAudioService _audioService;

    public void Construct(IAudioService audioService)
    {
        _audioService = audioService;
    }

    private void Start()
    {
        NextPageButton.onClick.AddListener(TurnOverNextPage);
        NextPageButton.onClick.AddListener(CheckButtonState);

        PreviousPageButton.onClick.AddListener(TurnOverPreviousPage);
        PreviousPageButton.onClick.AddListener(CheckButtonState);

        InitializePages();
        CheckButtonState();
    }

    private void InitializePages()
    {
        _pageIndex = 0;
        foreach (GameObject page in Pages)
        {
            page.SetActive(false);
        }
        _currentPage = Pages[_pageIndex];
        _currentPage.SetActive(true);
    }

    private void CheckButtonState()
    {
        if(_pageIndex <= 0)
        {
            PreviousPageButton.gameObject.SetActive(false);
        }
        else
        {
            PreviousPageButton.gameObject.SetActive(true);
        }

        if(_pageIndex >= Pages.Length - 1)
        {
            NextPageButton.gameObject.SetActive(false);
        }
        else
        {
            NextPageButton.gameObject.SetActive(true);
        }
    }

    private void TurnOverPreviousPage()
    {
        if(_pageIndex > 0)
        {
            _currentPage.SetActive(false);
            _pageIndex--;
            _currentPage = Pages[_pageIndex];
            _currentPage.SetActive(true);
        }
        _audioService.PlaySound("ButtonSound");
    }

    private void TurnOverNextPage()
    {
        if (_pageIndex < Pages.Length-1)
        {
            _currentPage.SetActive(false);
            _pageIndex++;
            _currentPage = Pages[_pageIndex];
            _currentPage.SetActive(true);
            _audioService.PlaySound("ButtonSound");
        }
    }
}
