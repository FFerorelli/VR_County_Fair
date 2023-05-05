using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] XRRayInteractor[] _teleportationInteractors;

    private ActionBasedControllerManager[] _actionBasedControllerManagers;
    private DynamicMoveProvider _dynamicMoveProvider;
    private ContinuousTurnProviderBase _continuousMoveProvider;
    private GrabMoveProvider[] _grabMoveProviders;
    private LocomotionManager _locomotionManager;


    private void Awake()
    {
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
    public bool ToggleSnapTurn()
    {
        foreach (var controllerManager in _actionBasedControllerManagers)
        {
            controllerManager.smoothTurnEnabled = !controllerManager.smoothTurnEnabled;
        }

        return !_actionBasedControllerManagers[0].smoothTurnEnabled;
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
        _dynamicMoveProvider.moveSpeed = canMove ? 1 : 0;

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

    void EnableLeftHandMoveAndStrafe()
    {
        _locomotionManager.leftHandLocomotionType = LocomotionManager.LocomotionType.MoveAndStrafe;
        //m_LeftHandMovementDirectionSelection.SetActive(true);
        //m_LeftHandTurnStyleSelection.SetActive(false);
    }

    void EnableRightHandMoveAndStrafe()
    {
        _locomotionManager.rightHandLocomotionType = LocomotionManager.LocomotionType.MoveAndStrafe;
        //m_RightHandMovementDirectionSelection.SetActive(true);
        //m_RightHandTurnStyleSelection.SetActive(false);
    }

    void EnableLeftHandTeleportAndTurn()
    {
        _locomotionManager.leftHandLocomotionType = LocomotionManager.LocomotionType.TeleportAndTurn;
        //m_LeftHandMovementDirectionSelection.SetActive(false);
        //m_LeftHandTurnStyleSelection.SetActive(true);
    }

    void EnableRightHandTeleportAndTurn()
    {
        _locomotionManager.rightHandLocomotionType = LocomotionManager.LocomotionType.TeleportAndTurn;
        //m_RightHandMovementDirectionSelection.SetActive(false);
        //m_RightHandTurnStyleSelection.SetActive(true);
    }

}
