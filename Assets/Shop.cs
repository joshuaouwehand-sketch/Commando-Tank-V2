using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public MonoBehaviour movementscript;
    public GameObject firstSelected; // Health button

    private bool playerInRange;
    private InputAction interactAction;

    private void Start()
    {
        shopUI.SetActive(false);

        interactAction =
            InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (playerInRange &&
            interactAction != null &&
            interactAction.WasPressedThisFrame())
        {
            bool open = !shopUI.activeSelf;
            movementscript.enabled = !open;
            shopUI.SetActive(open);

            if (open)
            {
               

                EventSystem.current
                    .SetSelectedGameObject(firstSelected);
            }
            else
            {
                 EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            movementscript.enabled = true;
            shopUI.SetActive(false);

            EventSystem.current
                .SetSelectedGameObject(null);
        }
    }
}