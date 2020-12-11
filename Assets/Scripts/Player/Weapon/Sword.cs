using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{

    private Animator swordAnimator;
    private AudioSource audioSource;
    public AudioClip[] swordSwingClips;
    public AudioClip[] swordImpactClips;
    public AudioClip[] swordImpactEnemyClips;

    public bool swinging = false;
    public int damage = 30;
    private bool playedSoundRecently = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        swordAnimator = gameObject.GetComponent<Animator>();
    }

    public void Swing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Swing!");
            if (swordAnimator.GetBool("isSwinging") == false)
            {
                swordAnimator.SetBool("isSwinging", true);
                swinging = true;
                swordAnimator.Play("SwordSwing");
                
            }
            else
            {
                //Debug.Log("In middle of swing animation!!!");
            }
        }
        else
            swinging = false;
    }

    public void PlaySwordSwing()
    {
        int rand = Random.Range(0, swordSwingClips.Length - 1);
        
        audioSource.PlayOneShot(swordSwingClips[rand]);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if it hasn't played sound recently, play sound, only if we're swinging (to prevent collisions from triggering it without swinging
        if (!playedSoundRecently && swordAnimator.GetBool("isSwinging"))
        {
            Invoke("TogglePlayedSoundRecently", .3f);
            playedSoundRecently = true;

            if (other.CompareTag("SkullEnemy") || other.CompareTag("Skeleton"))
            {
                int rand = Random.Range(0, swordImpactEnemyClips.Length - 1);
                audioSource.PlayOneShot(swordImpactEnemyClips[rand]);
            }
            else
            {
                int rand = Random.Range(0, swordImpactClips.Length - 1);
                audioSource.PlayOneShot(swordImpactClips[rand]);
            }

        }
    }

    private void TogglePlayedSoundRecently()
    {
        playedSoundRecently = !playedSoundRecently;
    }
}
