using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemToggle : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void TurnOnParticles()
    {
        var emmision = ps.emission;
        emmision.enabled = true;
    }

    public void TurnOffParticles()
    {
        var emmision = ps.emission;
        emmision.enabled = false;
    }
}
