using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent OnDeath;
    [SerializeField] int health = 100;
    private bool isDead = false;


    //given a value, remove value from health
    public void RemoveHealth(int value)
    {
        health -= value;
        CheckDead();
    }

    private void CheckDead()
    {
        //if dead, invoke the OnDeath event, which calls attached functions
        if(health <= 0)
        {
            isDead = true;
            OnDeath.Invoke();
        }
    }

}
