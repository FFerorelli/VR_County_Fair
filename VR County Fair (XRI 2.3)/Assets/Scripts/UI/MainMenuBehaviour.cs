using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject SettingsScreen;

    public void OnStartClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Start);
        mainMenuScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void OnSettingsClicked()
    {
        mainMenuScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }
    public void OnQuitClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Quit);
    }
    public void OnToggleSnapTurnClicked()
    {

    }
    public void OnSettingsBackClicked()
    {
        mainMenuScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }
}
