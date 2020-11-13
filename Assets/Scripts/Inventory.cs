using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{

    private bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (menuOpen)
            {
                Time.timeScale = 1;
                Debug.Log("Close the menu!");
            }
            else
            {
                Time.timeScale = 0;
                Debug.Log("Open the menu!");
            }

            menuOpen = !menuOpen;
        }
        
    }
}
