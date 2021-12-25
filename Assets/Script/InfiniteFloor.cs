using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFloor : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;

    public float timeOffset;
    public float distanceBetweenTiles;
    public float randomValue;

    private Vector3 previousTilePosition;
    private float startTime;
    private float k;
    private Vector3 direction;
    private Vector3 mainDirection = new Vector3(0, 0, 1);       //直走
    private Vector3 otherDirection1 = new Vector3(1, 0, 0);      //右轉
    private Vector3 otherDirection2 = new Vector3(-1, 0, 0);     //左轉

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            //k = Random.value;
            if (Random.value < randomValue)
            {
                direction = mainDirection;
            }
            else
            {
                Vector3 temp = direction;
                direction = otherDirection1;
                mainDirection = direction;
                otherDirection1 = temp;
                /*
                if (k >= (randomValue / 2))
                {
                    Vector3 temp = direction;
                    direction = otherDirection1;
                    mainDirection = direction;
                    otherDirection1 = temp;
                }
                else
                {
                    Vector3 temp = direction;
                    direction = otherDirection2;
                    mainDirection = direction;
                    otherDirection2 = temp;
                }
                */
                
            }

            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }

        //T字路



        //產生坑洞
    }
}
