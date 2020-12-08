using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    private Text scoreDisplay;
    float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //can comment these out and it should still work. If you do, uncomment the code in addScore.
        scoreDisplay = GameObject.FindGameObjectWithTag("ScoreNum").GetComponent<Text>();
        scoreDisplay.text = currentScore.ToString();
    }

    public void addScore(int value) {
        currentScore = currentScore + value;
        //scoreDisplay = GameObject.FindGameObjectWithTag("ScoreNum").GetComponent<Text>();
        scoreDisplay.text = currentScore.ToString();
    }
}
