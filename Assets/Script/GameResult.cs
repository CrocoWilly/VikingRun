using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public Text score;
    public Text time;
    void Start()
    { 
        string scoreStr = (VikingController.totalScore).ToString();
        score.text = scoreStr;

        string timeStr = (VikingController.survivalTime).ToString("F2");
        time.text = "Survival time: " + timeStr + " sec";
    }

}
