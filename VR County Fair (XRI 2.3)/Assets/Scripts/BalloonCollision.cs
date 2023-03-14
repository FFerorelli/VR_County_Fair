using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    // [SerializeField] private GameObject asteroidExplosion;
    private DarthBoothService _darthBoothService;
    void Start()
    {
        _darthBoothService = FindObjectOfType<DarthBoothService>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baloon")
        {

            collision.gameObject.SetActive(false);
            _darthBoothService.PopBallon();

            // Instantiate(asteroidExplosion, collision.transform.position, collision.transform.rotation);
            //GameManager.AsteroidHit();

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
