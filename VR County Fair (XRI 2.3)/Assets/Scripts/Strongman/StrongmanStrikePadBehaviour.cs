using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongmanStrikePadBehaviour : MonoBehaviour
{
    private StrongmanService _strongmanService;
    // Start is called before the first frame update
    void Start()
    {
        _strongmanService = FindObjectOfType<StrongmanService>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            var hammerRb = collision.gameObject.GetComponentInParent<Rigidbody>();
            var hammerBehaviour = collision.gameObject.GetComponentInParent<StrongmanHammerBehaviour>();
            _strongmanService.Strike(hammerRb.mass, collision.relativeVelocity.magnitude, hammerBehaviour.StrikeMultiplier);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
