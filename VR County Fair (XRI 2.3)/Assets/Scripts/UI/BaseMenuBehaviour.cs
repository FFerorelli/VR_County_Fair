using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class BaseMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private TMP_Text turnSpeedValueText;
    [SerializeField] private Slider turnSpeedSlider;
    //[SerializeField] private Text SnapTurnButtonText;
    [SerializeField] private TMP_Dropdown rightHandLocomotion;
    [SerializeField] private TMP_Dropdown leftHandLocomotion;
    [SerializeField] private Toggle leftSnapTurnToggle;
    [SerializeField] private Toggle rightSnapTurnToggle;
    [SerializeField] private Toggle comfortModeToggle;

    private PlayerBehaviour _playerBehaviour;
    private bool _isMenuOpen;

    private void Start()
    {
        _playerBehaviour = FindAnyObjectByType<PlayerBehaviour>();
        _playerBehaviour.OnTurnSpeedChanged += HandleTurnSpeedChanged;
        _playerBehaviour.OnChangeLeftMovementType += HandleLeftHandLocomotionChange;
        _playerBehaviour.OnChangeRightMovementType += HandleRightHandLocomotionChange;
        _playerBehaviour.OnToggleLeftSnapTurn += HandleToggleLeftSnapTurn;
        _playerBehaviour.OnToggleRightSnapTurn += HandleToggleRightSnapTurn;
        _playerBehaviour.OnToggleComfortMode += HandleComfortModeChange;

    }



    private void OnDestroy()
    {
        _playerBehaviour.OnTurnSpeedChanged -= HandleTurnSpeedChanged;
        _playerBehaviour.OnChangeLeftMovementType -= HandleLeftHandLocomotionChange;
        _playerBehaviour.OnChangeRightMovementType -= HandleRightHandLocomotionChange;
        _playerBehaviour.OnToggleLeftSnapTurn -= HandleToggleLeftSnapTurn;
        _playerBehaviour.OnToggleRightSnapTurn -= HandleToggleRightSnapTurn;
        _playerBehaviour.OnToggleComfortMode -= HandleComfortModeChange;
    }
    public virtual void ToggleMenu()
    {
        _isMenuOpen = !_isMenuOpen;
        mainMenuScreen.SetActive(_isMenuOpen);
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

    public void OnSettingsBackClicked()
    {
        mainMenuScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void OnTurnSpeedSliderValueChange(Slider slider)
    {
        //Debug.Log("turnSpeedSlider.value " + slider.value);
        turnSpeedValueText.text = Math.Ceiling(slider.value).ToString(); 
        _playerBehaviour.ChangeTurnSpeed(slider.value);
    }
    public void HandleTurnSpeedChanged(float turnSpeed)
    {
        turnSpeedValueText.text = Math.Ceiling(turnSpeed).ToString();
        turnSpeedSlider.value = turnSpeed;
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
        Debug.Log(dropDown.value);
    }
    public void OnLeftHandLocomotionChange(TMP_Dropdown dropDown)
    {
        if (dropDown.value == 0)
        {
            
            _playerBehaviour.EnableLeftHandMoveAndStrafe();
        }
        else
        {
            _playerBehaviour.EnableLeftHandTeleportAndTurn();
        }
        Debug.Log(dropDown.value);
    }

    public void HandleLeftHandLocomotionChange(int dropDownValue)
    {
        leftHandLocomotion.value = dropDownValue;
    }
    public void HandleRightHandLocomotionChange(int dropDownValue)
    {
        rightHandLocomotion.value = dropDownValue;
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
    public void HandleToggleLeftSnapTurn(bool snap)
    {
        leftSnapTurnToggle.isOn = snap;
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
    private void HandleToggleRightSnapTurn(bool snap)
    {
        rightSnapTurnToggle.isOn = snap;
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
    public void HandleComfortModeChange(bool comfortMode)
    {
        comfortModeToggle.isOn = comfortMode;
    }
}
