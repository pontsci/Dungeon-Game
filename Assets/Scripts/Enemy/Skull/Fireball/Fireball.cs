using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] Transform target; //the target we want to fly towards
    private Vector3 targetPosition;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetPosition = target.position;
        Invoke("DestroySelf", 1f);
    }

    public void Update()
    {
        transform.Translate(targetPosition*(Time.deltaTime*0.1f));
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
