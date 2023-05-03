using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossBoothService : MonoBehaviour
{
    [SerializeField] GameObject[] rings;
    [SerializeField] private int scoreToAdd = 10;

    public event Action<int> ScoreUpdated;

    private int _Score = 0;
    private Vector3[] _ringStartingPositions;
    private Quaternion[] _ringStartingRotations;
    public void AddToScore()
    {
        _Score += scoreToAdd;
        ScoreUpdated?.Invoke(_Score);
    }
    private void Start()
    {
        _ringStartingPositions = new Vector3[rings.Length];
        _ringStartingRotations = new Quaternion[rings.Length];
        for (int i = 0; i < rings.Length; i++)
        {
            _ringStartingPositions[i] = rings[i].transform.position;
            _ringStartingRotations[i] = rings[i].transform.rotation;
        }
    }
    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        for (int i = 0; i < rings.Length; i++)
        {
            rings[i].transform.SetPositionAndRotation(_ringStartingPositions[i], _ringStartingRotations[i]);
        }

        _Score = 0;
        ScoreUpdated?.Invoke(_Score);
    }
}
