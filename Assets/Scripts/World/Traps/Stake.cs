using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public TrapObject stakeData;
    private Health playerHealthScript;

    public AudioClip scoreAudio;
    private AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealthScript = other.gameObject.GetComponent<Health>();
            playerHealthScript.RemoveHealth(stakeData.removeHealthValue);
            soundSource.PlayOneShot(scoreAudio, 1.0f);
        }
    }
}
