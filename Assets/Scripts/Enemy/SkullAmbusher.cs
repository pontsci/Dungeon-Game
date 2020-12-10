using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAmbusher : Skull
{    // Update is called once per frame
    void Update()
    {
        if (playerDetector.playerDetected) {
            agent.SetDestination(playerTransform.position);
        }
    }
}
