using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public List<GameObject> interactableGameObjectsInRange = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        //if we have gotten into range of an interactable, add it to those interactables within range of the player.
        var interactable = other.GetComponent<Interactable>();
        if (interactable)
        {
            Debug.Log("This object: " + gameObject +" found an interactable! -> " + interactable);
            Debug.Log("Adding it to our in range interactables!");
            interactableGameObjectsInRange.Add(other.gameObject);
            Debug.Log("Our interactables size so far: " + interactableGameObjectsInRange.Count);
        }


        //var item = other.GetComponent<Item>();
        //if (item)
        //{
        //    inventory.AddItem(item.item, 1);
        //    item.PickupAction();
            //Destroy(other.gameObject);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<Interactable>();
        if (interactable)
        {
            Debug.Log("This object: " + gameObject + " found an interactable! -> " + interactable);
            Debug.Log("Adding it to our in range interactables!");
            interactableGameObjectsInRange.Remove(other.gameObject);
            Debug.Log("Our interactables size so far: " + interactableGameObjectsInRange.Count);
        }
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
        /*if (interactablesInRange[0] != null)
        {
            interactablesInRange[0].Activate(context);
        }*/
    }

    public void RemoveInteractableFromInteractableGameObjectsInRange(GameObject obj)
    {
        interactableGameObjectsInRange.Remove(obj);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
