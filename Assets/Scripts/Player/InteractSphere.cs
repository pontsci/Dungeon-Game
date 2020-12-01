using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSphere : MonoBehaviour
{


    public List<GameObject> interactableGameObjectsInRange = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        //if we have gotten into range of an interactable, add it to those interactables within range of the player.
        var interactable = other.GetComponent<Interactable>();
        if (interactable)
        {
            Debug.Log("This object: " + gameObject + " found an interactable! -> " + interactable);
            Debug.Log("Adding it to our in range interactables!");
            AddInteractableFromInteractableGameObjectsInRange(other.gameObject);
            Debug.Log("Our interactables size so far: " + interactableGameObjectsInRange.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<Interactable>();
        if (interactable)
        {
            Debug.Log("This object: " + gameObject + " found an interactable! -> " + interactable);
            Debug.Log("Adding it to our in range interactables!");
            RemoveInteractableFromInteractableGameObjectsInRange(other.gameObject);
            Debug.Log("Our interactables size so far: " + interactableGameObjectsInRange.Count);
        }
    }

    private void RemoveInteractableFromInteractableGameObjectsInRange(GameObject obj)
    {
        interactableGameObjectsInRange.Remove(obj);
    }

    private void AddInteractableFromInteractableGameObjectsInRange(GameObject obj)
    {
        interactableGameObjectsInRange.Add(obj);
    }
}
