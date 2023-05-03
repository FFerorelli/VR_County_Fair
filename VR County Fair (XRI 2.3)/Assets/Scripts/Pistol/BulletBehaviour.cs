using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    public float thrust = 10.0f;
    float waitTime = 2.0f;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnEnable()
    {
        coroutine = WaitToDisable(waitTime);
        StartCoroutine(coroutine);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (transform.forward) * thrust;
    }
    private IEnumerator WaitToDisable(float wait)
    {
        yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);

         Debug.Log("bullet disabled after " + waitTime + "seconds");

    }
}
