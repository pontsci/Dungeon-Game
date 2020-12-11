using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Transform target; //the target we want to fly towards
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float lifetime = 10f;
    [SerializeField] float particleDeathTime = 1f; //the time it takes for the particle system to die after a collision
    [SerializeField] int damage = 15;
    [SerializeField] float thrust;

    private ParticleSystem ps;

    private Vector3 targetPosition;
    private Rigidbody rb;
    private Vector3 relativePos;

    public void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetPosition = target.position;

        //a vector to the target
        relativePos = target.position - transform.position;
        Invoke("DestroySelf", lifetime);

        //throw the rb at the player
        rb.AddForce(new Vector3(relativePos.x, relativePos.y + 1.5f, relativePos.z) * thrust);

        //look at the target
        transform.rotation = Quaternion.LookRotation(new Vector3(relativePos.x, relativePos.y + 1, relativePos.z));
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //hit!
            collision.gameObject.GetComponent<Health>().RemoveHealth(damage);
        }

        //detach the particle system so it dies naturally
        GameObject ballParticles = transform.Find("Ball").gameObject;
        //get it take away its parent so it is not deleted with it
        ballParticles.transform.parent = null;
        //stop its particles
        ballParticles.GetComponent<ParticleSystem>().Stop();
        //destroy it later
        Destroy(ballParticles, particleDeathTime);

        //destroy the rest now
        Destroy(gameObject);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
