using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : MonoBehaviour
{
    public AudioClip swing;
    AudioSource audioSource;
    LookAtPlayer vision;

    [SerializeField]
    int health = 100;

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

        isDead();
    }

    public void damage(int takeDamage)
    {
        health -= takeDamage;
    }

    private void isDead()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
