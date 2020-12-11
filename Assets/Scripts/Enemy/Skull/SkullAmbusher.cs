using UnityEngine;
using UnityEngine.Events;


//this class handles the animations for the skull ambusher enemy, most variables are already set by the parent class
public class SkullAmbusher : Skull
{    
    private Animator animatorController;
    public UnityEvent particleSystemOn;
    public UnityEvent particleSystemOff;

    protected override void Start()
    {
        base.Start();
        animatorController = GetComponentInChildren<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        //if we're at the spawn, then we need to go into the spawn idle position
        if (isAtSpawn)
        {
            animatorController.SetBool("isAtSpawn", true);
        }
        
    }

    //go back to the spawn and set back down
    public override void LosePlayer()
    {
        agent.SetDestination(spawnPosition);
        agent.stoppingDistance = spawnStoppingDistance;
        animatorController.SetBool("playerDetected", false);
        Invoke("ParticlesOff", 5f);
    }

    private void ParticlesOff()
    {
        particleSystemOff.Invoke();
    }

    public override void DetectPlayer()
    {
        base.DetectPlayer();
        animatorController.SetBool("playerDetected", true);
        animatorController.SetBool("isAtSpawn", false);
        particleSystemOn.Invoke();
    }
}
