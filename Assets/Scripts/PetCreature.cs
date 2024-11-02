using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.XR;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;
//using UnityEngine.XR.Interaction.Toolkit;

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
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics & leftControllerCharacteristics, devices);
        
        foreach (var item in devices) 
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0 & 1];
        }


        canPet = false;
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("petCheck") & canPet)
        {            
            creAnim.PetCreatureAnimation();
            Debug.Log("play animation for petting");
        }
        else
        {
            if (creAnim != null)
            {
                creAnim.neutralCreatureAnimation();
            }
            
        }
    }


   
    private void Update()
    {
        petObj = GameObject.FindWithTag("creature");
        //Debug.Log(petObj);
        if (petObj != null)
        {
            creAnim = petObj.GetComponent<creatureAnimation>();
            //Debug.Log(creAnim);
        }
       
        canPet = false;

        if (CheckPettingSpeed(targetDevice)) 
        {
            canPet = true;  
        }

       

    }

    private bool CheckPettingSpeed(InputDevice controller)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity) )
        {
            float speed = velocity.magnitude;
            return speed >= minPettingSpeed && speed <= maxPettingSpeed;
            
        }

        return false;
    }

}

