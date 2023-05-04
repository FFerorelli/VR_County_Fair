using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private Slider turnSpeedSlider;
    [SerializeField] private Text SnapTurnButtonText;

    private PlayerBehaviour _playerBehaviour;
    private void Start()
    {
        _playerBehaviour = FindAnyObjectByType<PlayerBehaviour>();
        //turnSpeedSlider.onValueChanged.AddListener(delegate { OnTurnSpeedSliderValueChange(); } );
    }
    public void OnStartClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
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
       bool isSnapTurnOn = _playerBehaviour.ToggleSnapTurn();
        if (isSnapTurnOn)
        {
            SnapTurnButtonText.text = "Toggle Snap Turn: On";
        }
        else
        {
            SnapTurnButtonText.text = "Toggle Snap Turn: Off";
        }
    }
    public void OnSettingsBackClicked()
    {
        mainMenuScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void OnTurnSpeedSliderValueChange(Slider slider)
    {
        Debug.Log("turnSpeedSlider.value " + slider.value);
        _playerBehaviour.ChangeTurnSpeed(slider.value);
    }

}
