using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarthBoothService : MonoBehaviour
{
    [SerializeField] GameObject[] balloons;


    private int _ballonsPopped;
    private float _timer;
    public float Timer => _timer;
    private bool _isTimerRunning;
    public bool IsTimerRunning => _isTimerRunning;

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void StartGame()
    {
        _isTimerRunning = true;
    }

    public void PopBallon()
    {
        _ballonsPopped++;
        if (_ballonsPopped == balloons.Length)
        {
            PauseGame();
        }
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        _ballonsPopped = 0;
        _timer = 0;

        foreach (GameObject balloon in balloons)
        {
            balloon.gameObject.SetActive(true);
        }
    }

    private void PauseGame()
    {
        _isTimerRunning = false;
    }
}
