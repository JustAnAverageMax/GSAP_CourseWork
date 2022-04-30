using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float intecractionDistance;
    public TMPro.TextMeshProUGUI interactionText;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        bool successfulHit = false;
        
        if (Physics.Raycast(ray, out hit, intecractionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit) interactionText.text = "";
    }

    private void HandleInteraction(Interactable interactable)
    {
        KeyCode code = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(code))
                {
                    interactable.Interact();
                }

                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(code))
                {
                    interactable.Interact();
                }

                break;
            default:
                throw new System.Exception("Unsupported type of interaction");
            
        }

        throw new System.NotImplementedException();
    }
}