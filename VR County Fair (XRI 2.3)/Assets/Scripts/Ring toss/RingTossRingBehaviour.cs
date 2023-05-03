using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossRingBehaviour : MonoBehaviour
{
    private bool _isAroundBottle = false;

    private RingTossBoothService _ringTossBoothService;
    // Start is called before the first frame update
    void Start()
    {
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            _isAroundBottle = true;
            StopAllCoroutines();
            StartCoroutine(ScoreDelay());

        }
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            _isAroundBottle = false;
        }
    }
    private IEnumerator ScoreDelay()
    {
        yield return new WaitForSeconds(3f);
        if (_ringTossBoothService != null &&_isAroundBottle)
        {
            _ringTossBoothService.AddToScore();
        // Add to the score
        }
    }
}
