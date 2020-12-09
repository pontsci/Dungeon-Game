using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    private Text scoreDisplay;
    float elapsed = 0f;

    public AudioClip scoreAudio;
    private AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        //can comment these out and it should still work. If you do, make sure to uncomment the code in addScore.
        scoreDisplay = GameObject.FindGameObjectWithTag("ScoreNum").GetComponent<Text>();
        scoreDisplay.text = currentScore.ToString();
        soundSource = GetComponent<AudioSource>();
    }

    public void addScore(int value) {
        currentScore = currentScore + value;
        //scoreDisplay = GameObject.FindGameObjectWithTag("ScoreNum").GetComponent<Text>();
        soundSource.PlayOneShot(scoreAudio, 1.0f);
        scoreDisplay.text = currentScore.ToString();
    }
}