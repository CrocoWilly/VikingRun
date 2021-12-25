using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static int totalScore;
    public Transform coin;

    // Start is called before the first frame update
    void Start()
    {
        Transform c = Instantiate(coin);

        c.parent = transform;
        c.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
