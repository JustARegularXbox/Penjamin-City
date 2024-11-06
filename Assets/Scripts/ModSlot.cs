using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlot : MonoBehaviour
{
    public GameObject gameObj;
    public GameManager gameManager;

    private void Awake()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        CheckCombination(other.tag, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        //IT ONLY CHECKS THE BOOLS WHEN YOU PLACE THE GENES
        Debug.Log(other);
        Invoke("SpawnPreview", 0.5);
        Debug.Log("collide");
    }

    private void SpawnPreview()
    {
        ModCheck.instance.CreaturePreview();
    }

    private void OnTriggerExit(Collider other)
    {
        // When the object leaves the trigger, set the attribute to false
        CheckCombination(other.tag, false);
        gameManager.ClearSpawnedPreviews();
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
        
    }
   

    
    }
