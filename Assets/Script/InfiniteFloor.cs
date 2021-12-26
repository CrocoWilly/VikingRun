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

    private bool theFirst = false;          //if theFirst == true 表第一塊地板是往右邊的

    private Vector3 previousTilePosition;
    private float startTime;
    private float k;
    private Vector3 direction;
    private Vector3 mainDirection = new Vector3(0, 0, 1);       //直走
    private Vector3 otherDirection1 = new Vector3(1, 0, 0);      //右轉
    private Vector3 otherDirection2 = new Vector3(-1, 0, 0);     //左轉

    private bool lastDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
        TheFirstFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        { 
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
            GameObject floor = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;

            //產生坑洞
            if ((lastDestroy == false) && (Random.value < 0.05))
            {
                Destroy(floor);
                lastDestroy = true;
            }
            else if(Random.value >= 0.05)
            {
                lastDestroy = false;
            }
        }

        //T字路



        
    }

    private void TheFirstFloor()
    {
        direction = mainDirection;
        Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
        startTime = Time.time;
        GameObject floor = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
        previousTilePosition = spawnPos;
    }
}
