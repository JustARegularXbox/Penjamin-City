using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Genes : MonoBehaviour
{
    public GameObject spawnPoint;
    private Vector3 initialPosition;
    private bool isOverTarget = false;
    private Transform targetPosition;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Start()
    {
        initialPosition = transform.position;

        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectExited.AddListener(OnReleased);
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
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            spawnPoint.GetComponent<Spawner>().SpawnAtPoint();
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TargetArea"))
        {
            isOverTarget = false;
            targetPosition = null;
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
