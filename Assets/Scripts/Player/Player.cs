using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryCanvas; 
    public List<GameObject> interactableGameObjectsInRange; //interactable objects in range of the player
    public InteractSphere interactSphereScript;
    private FirstPersonController fpcScript; //the fps controller script
    private PlayerInput playerInput; //the PlayerInput component
    private InputAction interactAction; //the interactAction
    private InputAction meleeAttackAction; //the melleAttackAction
    private bool inventoryOpen = false;

    private void Start()
    {
        interactableGameObjectsInRange = interactSphereScript.interactableGameObjectsInRange;
        fpcScript = gameObject.GetComponent<FirstPersonController>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        interactAction = playerInput.actions.FindAction("Interact");
        meleeAttackAction = playerInput.actions.FindAction("Melee Attack");
        inventoryCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ActivateInteractableAtZeroIndex(InputAction.CallbackContext context)
    {
        //interact with the object if the inventory is not open
        if (context.performed && !inventoryOpen)
        {
            if(interactableGameObjectsInRange.Count != 0)
            {
                //activate our interactable object
                //Debug.Log("Activate this " + interactableGameObjectsInRange[0] + "!");
                var interactable = interactableGameObjectsInRange[0].gameObject.GetComponent<Interactable>();
                interactable.Activate();
            }
        }
    }

    public void ToggleInventory(InputAction.CallbackContext context)
    {
        if (context.performed && !inventoryOpen)
        {
            //Time.timeScale = 0;
            //open the inventory (render it) and freeze the player
            inventoryOpen = !inventoryOpen;
            inventoryCanvas.GetComponent<Canvas>().enabled = true;

            //disable the controller
            fpcScript.enabled = false;

            //disable actions
            interactAction.Disable();
            meleeAttackAction.Disable();

            //unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if(context.performed && inventoryOpen)
        {
            //close the inventory (cull it) and unfreeze the player
            inventoryOpen = !inventoryOpen;
            inventoryCanvas.GetComponent<Canvas>().enabled = false;

            //re-enable controller
            fpcScript.enabled = true;

            //re-enable actions
            interactAction.Enable();
            meleeAttackAction.Enable();

            //re-lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
        //this is just a mess, I need to clean it up. will do if have time.
        inventory.inventory.slots = new InventorySlot[24];
    }
}
