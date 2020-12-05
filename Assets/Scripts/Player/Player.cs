using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public List<GameObject> interactableGameObjectsInRange;
    public InteractSphere interactSphereScript;
    public int health = 100;
    public int food = 100;
    public int MAXHEALTH = 100;
    public int MAXFOOD = 100;

    private void Start()
    {
        interactableGameObjectsInRange = interactSphereScript.interactableGameObjectsInRange;
    }

    public void ActivateInteractableAtZeroIndex(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(interactableGameObjectsInRange.Count != 0)
            {
                //activate our interactable object
                Debug.Log("Activate this " + interactableGameObjectsInRange[0] + "!");
                var interactable = interactableGameObjectsInRange[0].gameObject.GetComponent<Interactable>();
                interactable.Activate(context);
            }
        }
    }

    // a test method for saving the inventory
    public void SaveInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Saving!");
            inventory.Save();
        }
    }

    // a test method for loading the inventory
    public void LoadInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Loading!");
            inventory.Load();
        }
    }

    public void RemoveInteractableFromInteractableGameObjectsInRange(GameObject obj)
    {
        interactSphereScript.interactableGameObjectsInRange.Remove(obj);
    }

    public void AddInteractableFromInteractableGameObjectsInRange(GameObject obj)
    {
        interactSphereScript.interactableGameObjectsInRange.Add(obj);
    }

    private void OnApplicationQuit()
    {
        inventory.inventoryContainer.Items = new InventorySlot[24];
    }
}
