
using System;
using System.Collections;
using UnityEngine;

public class StrongmanService : MonoBehaviour
{
    [SerializeField] private Transform slider;
    [SerializeField] private float maxHeight = 6.63f;
    [SerializeField] private float sliderDuration = 1f;

    private float _initialSliderHeight;
    private bool _isSliderMoving;

    // Start is called before the first frame update
    void Start()
    {
        _initialSliderHeight = slider.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Strike(float mass, float velocity, float multiplier)
    {
        Debug.Log("Strike " + mass + ", " + velocity + ", " + multiplier);

        // Physics calc
        float impactForce = mass * velocity;

        // move the slider
        float sliderHeight = Mathf.Clamp(impactForce * multiplier, _initialSliderHeight, maxHeight);

        if (!_isSliderMoving)
        {
             StartCoroutine(MoveSlider(sliderHeight));
        }
    }

    private IEnumerator MoveSlider(float targetHeight)
    {
        _isSliderMoving = true;

        // setup
        Vector3 startPos = new Vector3(slider.localPosition.x, _initialSliderHeight, slider.localPosition.z);
        Vector3 endPos = new Vector3(slider.localPosition.x, targetHeight, slider.localPosition.z);

        // slider up
        float elapsedTime = 0f;
        while (elapsedTime < sliderDuration)
        {
            slider.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / sliderDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // slider pause
        yield return new WaitForSeconds(sliderDuration);

        // slider down
        elapsedTime = 0f;
        while (elapsedTime < sliderDuration)
        {
            slider.localPosition = Vector3.Lerp(endPos, startPos, elapsedTime / sliderDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _isSliderMoving = false;
    }
}
