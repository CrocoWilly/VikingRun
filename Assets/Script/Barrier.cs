using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier: MonoBehaviour
{
    public GameObject[] barriers;
    public float spawnInterval;
    private Transform viking;
    int randomBarrier;

    private Vector3 xDirection = new Vector3(1, 0, 0);
    private Vector3 zDirection = new Vector3(0, 0, 1);


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
        randomBarrier = Random.Range(0, barriers.Length);

        Vector3 barrierPos;
        barrierPos.y = 4f;

        
        if(Random.value > 0.8)
        {
            barrierPos.x = viking.position.x + 2;
            barrierPos.z = viking.position.z;
        }
        else if(Random.value > 0.6)
        {
            barrierPos.x = viking.position.x + 1;
            barrierPos.z = viking.position.z - 2;
        }
        else if (Random.value > 0.4)
        {
            barrierPos.x = viking.position.x;
            barrierPos.z = viking.position.z + 1;
        }
        else if (Random.value > 0.2)
        {
            barrierPos.x = viking.position.x - 1;
            barrierPos.z = viking.position.z - 1;
        }
        else
        {
            barrierPos.x = viking.position.x - 2;
            barrierPos.z = viking.position.z + 2;
        }

        

        if (viking.transform.forward == zDirection)
        {
            Instantiate(barriers[randomBarrier], (barrierPos + viking.forward * 20), barriers[randomBarrier].transform.rotation);
        }

        if (viking.transform.forward == xDirection)
        {
            Instantiate(barriers[randomBarrier], (barrierPos + viking.forward * 20), Quaternion.Euler(0, 90f, 0));
        }
        
        StartCoroutine(createBarrier());
    }
}