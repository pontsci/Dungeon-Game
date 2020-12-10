using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public float detectionRadius = 7f;
    public UnityEvent lostDetection;
    private SphereCollider detectionSphere;
    public bool playerDetected { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        detectionSphere = GetComponent<SphereCollider>();
        detectionSphere.radius = detectionRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetected = false;
            lostDetection.Invoke();
        }
    }
}
