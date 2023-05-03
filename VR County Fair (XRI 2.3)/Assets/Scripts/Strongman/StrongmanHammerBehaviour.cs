
using UnityEngine;

public class StrongmanHammerBehaviour : MonoBehaviour
{
    public float StrikeMultiplier => strikeMultiplier;
    [SerializeField] private float strikeMultiplier;

    [SerializeField] private Transform centerOfMass;
    private Rigidbody _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rigidBody.centerOfMass = centerOfMass.localPosition;
    }
}
