using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class InGameMenuBehaviour : BaseMenuBehaviour
{
   //public GameObject inGameMenu;
   public InputActionProperty showButton;

    private void Update()
    {
        if (showButton.action.WasPerformedThisFrame() && GameManager.Instance.State == GameState.Play)
        {
            base.ToggleMenu();
        }
    }

}
