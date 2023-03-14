using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject bulletModel;
    public Transform bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void FireGun()
    {
        GameObject bullet = ObjectPool.instance.GetPooledPistolBullets();

        if (bullet != null)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            bullet.SetActive(true);

            Debug.Log("BOOM");
        }
        else
        {
            Debug.Log("Laser is null");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
