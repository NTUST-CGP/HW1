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
    
    public void SwitchToSettingMenu()
    {
        _startMenu.SetActive(false);
        _endMenu.SetActive(false);
        _settingMenu.SetActive(true);
    }
    public void SwitchtoStartMenu()
    {
        _settingMenu.SetActive(false);
        _exitMenu.SetActive(false);
        _endMenu.SetActive(false);
        _startMenu.SetActive(true);
    }
    public void SwitchToExitMenu()
    {
        _startMenu.SetActive(false);
        _endMenu.SetActive(false);
        _exitMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
