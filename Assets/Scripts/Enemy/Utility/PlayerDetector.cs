using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public float detectionRadius = 7f;
    public UnityEvent lostDetection;
    public UnityEvent gainedDetection;
    public bool expandDetection = false;
    public float expansionAmount = 5f;
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
        Debug.Log("The collider: " + other);
        Debug.Log("The collider's tag: " + other.tag);
        if(other.CompareTag("Player"))
        {
            playerDetected = true;
            if (expandDetection)
            {
                detectionSphere.radius += expansionAmount;
            }
            Debug.Log("In Range In Player Detector Script");
            gainedDetection.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerDetected = false;
            if (expandDetection)
            {
                detectionSphere.radius = detectionRadius;
            }
            lostDetection.Invoke();
        }
    }

}
