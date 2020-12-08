using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCamera : MonoBehaviour
{

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = new Quaternion(transform.eulerAngles.x, );
    }
}
