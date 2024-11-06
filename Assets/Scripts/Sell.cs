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
    public TriggerDialogue2 badBossFeedbackSC;

    //public SellMachine_animations sellAnimSC;
    
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

    public bool GetCanSell()
    {
        return canSell;
    }
    
   public void sellCreature()
    {
        if (canSell) 
        {
            goodBossFeedbackSC.SendLines();
            canSell = false;
            gameManager.ChangeOrder();
            Destroy(GameObject.FindWithTag("creature"));
            //sellAnimSC.Sold_animation();

            Debug.Log("sell creature");
        }
        else if (canEject)
        {
            badBossFeedbackSC.SendLines2();
            Destroy(GameObject.FindWithTag("creature"));
            //sellAnimSC.Kill_animation();
            Debug.Log("kill creature");
            canEject = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("creature"))
        {
            creatureAnimation animationSC  = other.GetComponent<creatureAnimation>();
            animationSC.SadCreatureAnimation();
            //animationSC.RotateCreature();

            if (gameManager.CheckOrder())
            {
                canSell = true;
                Debug.Log("canesell true");
                
            }
            else
            {
                canEject = true;
                Debug.Log("caneject true");

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
