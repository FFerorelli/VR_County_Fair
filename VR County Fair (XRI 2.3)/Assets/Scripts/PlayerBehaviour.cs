using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerBehaviour : MonoBehaviour
{
    //public static PlayerBehaviour Instance;

    [SerializeField] XRRayInteractor[] _teleportationInteractors;

    private ActionBasedControllerManager[] _actionBasedControllerManagers;
    private DynamicMoveProvider _dynamicMoveProvider;
    private ContinuousTurnProviderBase _continuousMoveProvider;
    private GrabMoveProvider[] _grabMoveProviders;
    private LocomotionManager _locomotionManager;


    private void Awake()
    {
        //if (Instance == null)
        //    Instance = this;
        //else
        //    Destroy(gameObject);

        _actionBasedControllerManagers = GetComponentsInChildren<ActionBasedControllerManager>();
        _dynamicMoveProvider = GetComponentInChildren<DynamicMoveProvider>();
        _grabMoveProviders = GetComponentsInChildren<GrabMoveProvider>();
        _continuousMoveProvider = GetComponentInChildren<ContinuousTurnProviderBase>();
        _locomotionManager = GetComponentInChildren<LocomotionManager>();
    }
    private void Start()
    {
        HandleGameStateChanged(GameManager.Instance.State);
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }


    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
               AllowPlayerMovement(false);
                break;
            case GameState.Play:
               AllowPlayerMovement(true);
                break;
            case GameState.Pause:
               AllowPlayerMovement(false);
                break;
            //case GameState.Quit:
            //    break;
            default:
                break;
        }
    }

    private void AllowPlayerMovement(bool canMove)
    {
        _dynamicMoveProvider.moveSpeed = canMove ? 10 : 0;

        foreach (var grabMoveProvider in _grabMoveProviders)
        {
            grabMoveProvider.enabled = canMove;
        }
        foreach (var teleportationInteractor in _teleportationInteractors)
        {
            teleportationInteractor.enabled = canMove;
        }
    }

    public void ChangeTurnSpeed(float sliderValue)
    {
        Debug.Log("TurnSpeed " + sliderValue);
        _continuousMoveProvider.turnSpeed = sliderValue;
    }

    public void EnableLeftHandMoveAndStrafe()
    {
        _locomotionManager.leftHandLocomotionType = LocomotionManager.LocomotionType.MoveAndStrafe;
    }

    public void EnableRightHandMoveAndStrafe()
    {
        _locomotionManager.rightHandLocomotionType = LocomotionManager.LocomotionType.MoveAndStrafe;
    }

    public void EnableLeftHandTeleportAndTurn()
    {
        _locomotionManager.leftHandLocomotionType = LocomotionManager.LocomotionType.TeleportAndTurn;
    }

    public void EnableRightHandTeleportAndTurn()
    {
        _locomotionManager.rightHandLocomotionType = LocomotionManager.LocomotionType.TeleportAndTurn;
    }
    public void ToggleLeftSnapTurn(bool snap)
    {
        if (snap == true)
        {
            _locomotionManager.leftHandTurnStyle = LocomotionManager.TurnStyle.Snap;
        }
        else
        {
            _locomotionManager.leftHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
        }
    }
    public void ToggleRightSnapTurn(bool snap)
    {
        if (snap == true)
        {
            _locomotionManager.rightHandTurnStyle = LocomotionManager.TurnStyle.Snap;
        }
        else
        {
            _locomotionManager.rightHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
        }
    }
    public void ToggleComfortMode(bool comfortMode)
    {

            _locomotionManager.enableComfortMode = comfortMode;
            
            if (_locomotionManager.tunnelingVignette != null)
                _locomotionManager.tunnelingVignette.SetActive(comfortMode);
    }
}
