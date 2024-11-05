using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sell : MonoBehaviour
{

    //public GameObject modCheck;
    //public ModCheck modCheckS;
    public static GameObject gameObj;
    public static GameManager gameManager;

    private bool canSell;
    private bool canEject;

    public TriggerDialogue goodBossFeedbackSC;
    public TriggerDialogue badBossFeedbackSC;

    private void Awake()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
    }
    private void Start()
    {   
        canSell = false;
        canEject = false;
    }
    
   public void sellCreature()
    {
        if (canSell) 
        {
            gameManager.ChangeOrder();
            Destroy(GameObject.FindWithTag("creature"));

            goodBossFeedbackSC.SendLines();

        }else if (canEject)
        {
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("creature"))
        {
            if (gameManager.CheckOrder())
            {
                canSell = true;
            }
            else
            {
                canEject = true;

                badBossFeedbackSC.SendLines();
            }
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
