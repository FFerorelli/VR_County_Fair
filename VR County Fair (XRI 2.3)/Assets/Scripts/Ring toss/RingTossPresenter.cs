using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingTossPresenter : MonoBehaviour
{
    [SerializeField] TMP_Text TMP_ScoreText;
    private RingTossBoothService _ringTossBoothService;
    // Start is called before the first frame update
    void Start()
    {
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
        if (_ringTossBoothService != null)
        {
            _ringTossBoothService.ScoreUpdated += OnScoreUpdated;
        }
    }
    private void OnScoreUpdated(int newScore)
    {
        TMP_ScoreText.text = "Score: " + newScore;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
