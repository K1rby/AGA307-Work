using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    // public TMP_Text difficultyText;
   // public TMP_Text timerText;

    public void UpdateScore (float _score)
    {
        scoreText.text = "Score: " + _score;
    }

    //public void UpdateTimer (float _timer)
    //{
    //    timerText.text = "Time Remaining: " + _timer.ToString("F2");

    //    if(_timer <= 10f)
    //    {
    //        timerText.color = Color.magenta;
    //    }
    //    else
    //    {
    //        timerText.color = Color.black;
    //    }
    //}

    /*public void difficulty.ToString()
    {
        difficultyText.text = "Difficulty: " + difficultyText;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
