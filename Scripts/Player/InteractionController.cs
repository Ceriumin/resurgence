using Resurgence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private List<InteractionObject> m_NearbyInteractables = new List<InteractionObject>();
    private Transform cameraTransform;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        cameraTransform = playerController.cameraTransform;

        RaycastHit hit;
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        //check if the hit object has outline script
        if (UnityEngine.Physics.Raycast(ray , out hit, playerController.interactionRadius, playerController.interactionMask) && hit.distance < playerController.interactionRange)
        {
            if (hit.collider.gameObject.GetComponent<Outline>())
            {
                if (hit.collider.gameObject.GetComponent<Plane>() && playerController.plane == null)
                {
                    hit.collider.gameObject.GetComponent<Outline>().OutlineWidth = 4f;
                    if(Input.GetKeyDown(KeyCode.E))
                        playerController.SetPlane(hit.collider.gameObject.GetComponent<Plane>());
                }
            }
        }

        else
        {
            Outline[] outlineScript = FindObjectsOfType(typeof(Outline)) as Outline[];
            foreach (var outline in outlineScript)
                outline.OutlineWidth = 0f;
        }
    }

    public bool HasNearbyInteractables()
    {
        return m_NearbyInteractables.Count != 0;
    }
}
