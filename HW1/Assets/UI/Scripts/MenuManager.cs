using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // private enum MENU
    // {
    //     START,
    //     SETTING,
    //     EXIT
    // }
    // private MENU _menu = MENU.START;
    [SerializeField]private GameObject _startMenu;
    [SerializeField]private GameObject _settingMenu;
    [SerializeField]private GameObject _exitMenu;
    [SerializeField]private GameObject _endMenu;
    [SerializeField]private GameObject _pauseMenu;
    [SerializeField]private GameObject _billBoard;
    private bool _isPause = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!_isPause)
                _isPause = true;
            else
                _isPause = false;
            _exitMenu.SetActive(_isPause);
        }
    }
    
    public void SwitchToSettingMenu()
    {
        _settingMenu.SetActive(true);
        _exitMenu.SetActive(false);
        _endMenu.SetActive(false);
        _startMenu.SetActive(false);
        _billBoard.SetActive(false);
        _pauseMenu.SetActive(false);
    }
    public void SwitchtoStartMenu()
    {
        _settingMenu.SetActive(false);
        _exitMenu.SetActive(false);
        _endMenu.SetActive(false);
        _startMenu.SetActive(true);
        _billBoard.SetActive(false);
        _pauseMenu.SetActive(false);
    }
    public void SwitchToExitMenu()
    {
        _settingMenu.SetActive(false);
        _exitMenu.SetActive(true);
        _endMenu.SetActive(false);
        _startMenu.SetActive(false);
        _billBoard.SetActive(false);
        _pauseMenu.SetActive(false);
    }
    public void StartGame()
    {
        _settingMenu.SetActive(false);
        _exitMenu.SetActive(false);
        _endMenu.SetActive(false);
        _startMenu.SetActive(false);
        _billBoard.SetActive(true);
        _pauseMenu.SetActive(false);
    }
    public void BackToGame()
    {
        _exitMenu.SetActive(false);
        _isPause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
