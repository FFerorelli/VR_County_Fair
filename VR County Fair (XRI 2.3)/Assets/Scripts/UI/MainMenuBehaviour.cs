using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private Slider turnSpeedSlider;
    [SerializeField] private Text SnapTurnButtonText;
    [SerializeField] private TMP_Text turnSpeedValueText;
    [SerializeField] private TMP_Dropdown rightHandLocomotion;
    [SerializeField] private TMP_Dropdown leftHandLocomotion;
    [SerializeField] private Toggle leftSnapTurnToggle;
    [SerializeField] private Toggle rightSnapTurnToggle;


    private PlayerBehaviour _playerBehaviour;
    private void Start()
    {
        _playerBehaviour = FindAnyObjectByType<PlayerBehaviour>();

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
    //public void OnToggleSnapTurnClicked()
    //{
    //   bool isSnapTurnOn = _playerBehaviour.ToggleSnapTurn();
    //    //if (isSnapTurnOn)
    //    //{
    //    //    SnapTurnButtonText.text = "Toggle Snap Turn: On";
    //    //}
    //    //else
    //    //{
    //    //    SnapTurnButtonText.text = "Toggle Snap Turn: Off";
    //    //}
    //}
    public void OnSettingsBackClicked()
    {
        mainMenuScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void OnTurnSpeedSliderValueChange(Slider slider)
    {
        Debug.Log("turnSpeedSlider.value " + slider.value);
        turnSpeedValueText.text = Math.Ceiling(slider.value).ToString(); ;
        _playerBehaviour.ChangeTurnSpeed(slider.value);
    }

    public void OnRightHandLocomotionChange(TMP_Dropdown dropDown)
    {
        if (dropDown.value == 0)
        {
            _playerBehaviour.EnableRightHandTeleportAndTurn();
        }
        else
        {
            _playerBehaviour.EnableRightHandMoveAndStrafe();
        }       
    }
    public void OnLeftHandLocomotionChange(TMP_Dropdown dropDown)
    {
        if (dropDown.value == 0)
        {
            Debug.Log(dropDown.value);
            _playerBehaviour.EnableLeftHandMoveAndStrafe();
        }
        else
        {
            _playerBehaviour.EnableLeftHandTeleportAndTurn();
        }       
    }

    public void OnToggleLeftSnapTurn(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _playerBehaviour.ToggleLeftSnapTurn(true);
        }
        else
        {
            _playerBehaviour.ToggleLeftSnapTurn(false);
        }
    }
    public void OnToggleRightSnapTurn(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _playerBehaviour.ToggleRightSnapTurn(true);
        }
        else
        {
            _playerBehaviour.ToggleRightSnapTurn(false);
        }
    }

}
