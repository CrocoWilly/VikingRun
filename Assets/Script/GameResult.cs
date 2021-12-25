using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public Text s;
    void Start()
    { 
        string scoreStr= (CoinSpawner.totalScore).ToString();
        s.text = scoreStr;
    }

}
