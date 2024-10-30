using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlot : MonoBehaviour
{
    public static GameObject gameObj;
    public static GameManager gameManager;

    private void Awake()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //IT ONLY CHECKS THE BOOLS WHEN YOU PLACE THE GENES
        Debug.Log(other);
        CheckCombination(other.tag, true);
        ModCheck.instance.CreaturePreview();
        Debug.Log("collide");
    }

    private void OnTriggerExit(Collider other)
    {
        // When the object leaves the trigger, set the attribute to false
        CheckCombination(other.tag, false);
        ModCheck.instance.CreaturePreview();
        Debug.Log("exit");
    }

    public void CheckCombination(string tag, bool state)
    {
        if (gameManager != null)
        {
            switch (tag)
            {
                case "intelligence":
                    gameManager.modInt = state;
                    break;
                case "ecoFriendly":
                    gameManager.modEco = state;
                    break;
                case "speed":
                    gameManager.modSpd = state;
                    break;
                case "power":
                    gameManager.modPwr = state;
                    break;
            }
        }
        Debug.Log("check combi");
    }
   

    
    }
