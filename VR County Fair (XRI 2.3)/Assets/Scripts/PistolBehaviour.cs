using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehaviour : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] float shootDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, shootDistance))
        {
            if (hit.transform.CompareTag("Baloon"))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
