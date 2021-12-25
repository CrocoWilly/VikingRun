using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject viking;
    public bool alive = true;

    SceneSwitcher switcher = new SceneSwitcher();

    // Start is called before the first frame update
    void Start()
    {
        viking = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (viking.transform.localPosition.y < -50)     //or¸òenemy¸I¨ì --> die
        {
            alive = false;
        }

        if (alive == false)
        {
            //Debug.Log("You Die");

            //¸õ¨ìgameResult Scene
            switcher.sceneIndexDestination = 3;
            switcher.changeScene();
        }
    }
}
