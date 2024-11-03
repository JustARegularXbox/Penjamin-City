using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Threading.Tasks;
using System;

public class PetCreature : MonoBehaviour
{
    private bool canPet;
    private InputDevice targetDevice;
    private GameObject petObj;
    private creatureAnimation creAnim;

    [SerializeField] private float minPettingSpeed = 0.1f;  
    [SerializeField] private float maxPettingSpeed = 0.5f;


    public static InputFeatureUsage<float> trigger;
    void Start()
    {
        StartCoroutine(passTime(5));      

        canPet = false;
    }

    private void OnTriggerStay (Collider other)
    {
        if ((other.CompareTag("RightHand") || other.CompareTag("LeftHand") & canPet)) 
        {                     
            
            creAnim.PetCreatureAnimation();
            Debug.Log("play animation for petting");
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightHand") || other.CompareTag("LeftHand"))
        {
            if (creAnim != null)
            {
                creAnim.neutralCreatureAnimation();
            }

        }
    }



    private void Update()
    {        
        creAnim = this.GetComponentInParent<creatureAnimation>();
        Debug.Log(creAnim);
        canPet = false;

        if (CheckPettingSpeed(targetDevice)) 
        {
            canPet = true;  
        }
    }

    private bool CheckPettingSpeed(InputDevice controller)
    {
        if (controller.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity) )
        {
            float speed = velocity.magnitude;
            return speed >= minPettingSpeed && speed <= maxPettingSpeed;
            
        }

        return false;
    }

    private IEnumerator passTime(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics & leftControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0 & 1];
            Debug.Log(targetDevice);
        }
        else
        {
            Debug.LogError("device count is 0");
        }

    }
}

