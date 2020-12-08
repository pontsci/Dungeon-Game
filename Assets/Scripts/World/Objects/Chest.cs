using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        //can comment this out and it should still work. If you do, make sure to uncomment the code in OnTriggerEnter.
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
            scoreManager.addScore(100);
            Destroy(gameObject);
        }
    }
}