using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Dialogue dialogueBoxCode;
    public string[] linesToBeActive;
    
    
    // Start is called before the first frame update

    public void SendLines()
    {
        dialogueBoxCode.ActivateLines(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
