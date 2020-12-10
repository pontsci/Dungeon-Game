using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleEndMenu() {
        //set score text
        gameObject.SetActive(true);
        //gameObject.GetComponent<Text>().text = scoreManager.currentScore.ToString();
        GameObject.FindGameObjectWithTag("DeathScore").GetComponent<Text>().text = scoreManager.currentScore.ToString();

    }

    public void ToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
