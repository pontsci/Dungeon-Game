using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : MonoBehaviour
{
    public AudioClip swing;
    AudioSource audioSource;
    LookAtPlayer vision;
    // Start is called before the first frame update
    void Start()
    {
        vision = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<LookAtPlayer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vision.playerReached)
        {
            audioSource.PlayOneShot(swing, .7F);
        }
    }
}
