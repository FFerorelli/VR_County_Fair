using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DarthBoothPresenter : MonoBehaviour
{
    [SerializeField] 
    TMP_Text TMP_Timer;
    private DarthBoothService _darthBoothService;
    // Start is called before the first frame update
    void Start()
    {
        _darthBoothService = FindObjectOfType<DarthBoothService>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_darthBoothService.IsTimerRunning)
        {
            TMP_Timer.text = "Timer: " + TimeSpan.FromSeconds(_darthBoothService.Timer).ToString("mm\\:ss\\:fff");
        }
    }
}
