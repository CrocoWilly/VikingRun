using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameCanvas : MonoBehaviour
{
    public Text score;
    public Text time;
    void Start()
    {
        //time.text = timeStart.ToString("F2");
        time.text = "Time: 0.00";
        score.text = "$: 0";
    }

    // Update is called once per frame
    void Update()
    {
        string scoreStr = (VikingController.totalScore).ToString();
        score.text = "$: " + scoreStr;

        string timeStr = (VikingController.survivalTime).ToString("F2");
        time.text = "Time: " + timeStr;
    }
}
