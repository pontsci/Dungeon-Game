using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int startScore = 0;
    public int currentScore;
    private Text scoreDisplay;
    float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In the start method for the ScoreManager");
        currentScore = startScore;
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        //scoreDisplay.text = currentScore.ToString();
        scoreDisplay.text = "" + currentScore;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 5f)
        {
            Debug.Log("Five seconds have past, adding 5 to our score");
            elapsed = elapsed % 5f;
            addScore(5);
        }
    }

    public void addScore(int value) {
        currentScore = currentScore + value;
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreDisplay.text = currentScore.ToString();
    }
}
