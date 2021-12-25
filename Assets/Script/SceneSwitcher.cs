using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//¸õ¨ìmain gameªºsceneSwitcher
public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int sceneIndexDestination;

    public void OnPointerClick(PointerEventData e)
    {
        /*
        //get the current state
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + " and scene index = " + scene.buildIndex);
        */

        //load a new scene
        changeScene();
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndexDestination);
    }

}
