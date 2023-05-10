using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InGameMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenuScreen;
    [SerializeField] private GameObject inGameSettingsScreen;
    [SerializeField] private Slider turnSpeedSlider;
   // [SerializeField] private Text SnapTurnButtonText;
    [SerializeField] private TMP_Text turnSpeedValueText;
    [SerializeField] private TMP_Dropdown rightHandLocomotion;
    [SerializeField] private TMP_Dropdown leftHandLocomotion;
    [SerializeField] private Toggle leftSnapTurnToggle;
    [SerializeField] private Toggle rightSnapTurnToggle;

    private PlayerBehaviour _playerBehaviour;
    private bool _isMenuOpen;


    private void Start()
    {
        _playerBehaviour = FindAnyObjectByType<PlayerBehaviour>();

    }

    public void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        inGameMenuScreen.SetActive(_isMenuOpen);
        inGameSettingsScreen.SetActive(false);
    }
    public void OnSettingsClicked()
    {
        inGameMenuScreen.SetActive(false);
        inGameSettingsScreen.SetActive(true);
    }
    public void OnQuitClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Quit);
    }

    public void OnSettingsBackClicked()
    {
        inGameMenuScreen.SetActive(true);
        inGameSettingsScreen.SetActive(false);
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
    public void OnToggleComfortMode(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _playerBehaviour.ToggleComfortMode(true);
        }
        else
        {
            _playerBehaviour.ToggleComfortMode(false);
        }
    }

}
