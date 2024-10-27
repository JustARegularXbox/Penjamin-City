using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlot : MonoBehaviour
{
     private bool intelligence;
     private bool power;
     private bool speed;
     private bool ecoFriendly;

    
    private void OnTriggerEnter(Collider other)
    {
        //IT ONLY CHECKS THE BOOLS WHEN YOU PLACE THE GENES

        ModCheck.instance.CreateCombination(other.tag, true);
        ModCheck.instance.Creaturepreview();
        Debug.Log("collide");
    }

    private void OnTriggerExit(Collider other)
    {
        // When the object leaves the trigger, set the attribute to false
        ModCheck.instance.CreateCombination(other.tag, false);
        ModCheck.instance.Creaturepreview();
        Debug.Log("exit");
    }

   

    
    }
