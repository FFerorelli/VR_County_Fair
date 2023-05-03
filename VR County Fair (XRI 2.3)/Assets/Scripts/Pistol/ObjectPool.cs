using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledPistolBullets = new List<GameObject>();
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int pistolAmountToPool = 20;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        IstantiatePistolBullets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void IstantiatePistolBullets()
    {
        for (int i = 0; i < pistolAmountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledPistolBullets.Add(obj);
        }
    }

    public GameObject GetPooledPistolBullets()
    {
        for (int i = 0; i < pooledPistolBullets.Count; i++)
        {
            if (!pooledPistolBullets[i].activeInHierarchy)
            {
                return pooledPistolBullets[i];
            }
        }
        return null;
    }
}
