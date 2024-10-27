using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sell : MonoBehaviour
{

    //public GameObject modCheck;
    //public ModCheck modCheckS;

    private bool canSell;

    private void Start()
    {
        //modCheckS = modCheck.GetComponent<ModCheck>();
        
        canSell = false;
    }
    
   public void sellCreature()
    {
        if (canSell) 
        {
            Destroy(GameObject.FindWithTag("creature"));

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("creature"))
        {
            canSell = true;

        }

    }



    /*public void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "intEco":
                modCheckS.intEco.SetActive(false);
                break;
            case "intSpd":
                modCheckS.intSpd.SetActive(false);
                break;
            default:
                break;
        }
    }*/
}
