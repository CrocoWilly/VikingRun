using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner: MonoBehaviour
{
    public GameObject coin;
    public float spawnInterval;
    private Transform viking;
    

    private Vector3 xDirection = new Vector3(1, 0, 0);
    private Vector3 zDirection = new Vector3(0, 0, 1);
    Quaternion coinRot;
    // Start is called before the first frame update
    void Start()
    {
        viking = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(createBarrier());
    }

    IEnumerator createBarrier()
    {
        yield return new WaitForSeconds(spawnInterval);
        spawn();
    }

    void spawn()
    {
        //randomCoin = Random.Range(0, barriers.Length);

        Vector3 coinPos;
   

        coinPos.y = 5f;

        if (Random.value > 0.8)
        {
            coinPos.x = viking.position.x + 2;
            coinPos.z = viking.position.z;
        }
        else if (Random.value > 0.6)
        {
            coinPos.x = viking.position.x + 1;
            coinPos.z = viking.position.z - 2;
        }
        else if (Random.value > 0.4)
        {
            coinPos.x = viking.position.x;
            coinPos.z = viking.position.z + 1;
        }
        else if (Random.value > 0.2)
        {
            coinPos.x = viking.position.x - 1;
            coinPos.z = viking.position.z - 1;
        }
        else
        {
            coinPos.x = viking.position.x - 2;
            coinPos.z = viking.position.z + 2;
        }



        if (viking.transform.forward == zDirection)
        {
            Instantiate(coin, (coinPos + viking.forward * 20), coin.transform.rotation);
        }

        if (viking.transform.forward == xDirection)
        {
            Instantiate(coin, (coinPos + viking.forward * 20), Quaternion.Euler(0f, 45f, 75f));
        }

        StartCoroutine(createBarrier());
    }
}