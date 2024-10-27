using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapCreature : MonoBehaviour
{
    public GameObject spawnPoint;
    private Vector3 initialPosition;
    [SerializeField] private bool isOverTarget = false;
    private Transform targetPosition;

    
    private bool genePlaced;

    private List<GameObject> Previews = new List<GameObject>();

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Start()
    {
        genePlaced = true;

        initialPosition = transform.position;

        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void InstantiateGenePreview(GameObject prefab)
    {
        if (prefab != null && !genePlaced)
        {

            GameObject preview = Instantiate(prefab, targetPosition.position, Quaternion.identity);
            Previews.Add(preview);
        }
    }

    private void OnPickedUp(SelectEnterEventArgs args)
    {
        TriggerHapticFeedback(args.interactorObject, 0.5f, 0.3f);

    }

    private void OnReleased(SelectExitEventArgs args)
    {
        TriggerHapticFeedback(args.interactorObject, 0.5f, 0.3f);

        if (isOverTarget && targetPosition != null)
        {
            genePlaced = true;

            transform.position = targetPosition.position;
            //transform.rotation = targetPosition.rotation;

            foreach (GameObject preview in Previews)
            {
                Destroy(preview);  // Destroy all previously spawned creatures
            }
            //spawnPoint.GetComponent<Spawner>().SpawnAtPoint();
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetArea"))
        {
            isOverTarget = true;
            targetPosition = other.transform;
            //InstantiateGenePreview(preview);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TargetArea"))
        {
            genePlaced = false;


            isOverTarget = false;
            targetPosition = null;

            foreach (GameObject preview in Previews)
            {
                Destroy(preview);  // Destroy all previously spawned creatures
            }
        }
    }

    private void TriggerHapticFeedback(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor, float intensity, float duration)
    {
        if (interactor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor)
        {
            XRBaseController controller = controllerInteractor.xrController;
            if (controller != null)
            {
                controller.SendHapticImpulse(intensity, duration);
            }
        }
    }
}
