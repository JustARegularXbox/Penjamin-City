using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue3 : MonoBehaviour
{
    public Dialogue dialogueBoxCode;
    public string[] linesToBeActive;


    // Start is called before the first frame update

    public void SendLines3()
    {
        dialogueBoxCode.ActivateLines(gameObject);
    }


}

