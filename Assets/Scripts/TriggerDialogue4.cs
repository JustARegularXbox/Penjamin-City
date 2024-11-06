using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue4 : MonoBehaviour
{
    public Dialogue dialogueBoxCode;
    public string[] linesToBeActive;


    // Start is called before the first frame update

    public void SendLines4()
    {
        dialogueBoxCode.ActivateLines(gameObject);
    }
}

