using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenuBehaviour : BaseMenuBehaviour
{
    public override void ToggleMenu()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        base.ToggleMenu();
    }

}
