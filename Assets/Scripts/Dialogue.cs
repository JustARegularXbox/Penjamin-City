using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public TriggerDialogue TriggerDialogueSC;
    public float textSpeed;
    

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
        textComponent.text = string.Empty;
        StartDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDialogue()
    {
        textComponent.text = string.Empty; // Clear all text from the screen
        index = 0; //start from the first line
        StartCoroutine(TypeLine()); //start typing the caharcters
    }

    IEnumerator TypeLine()
    {
        //take the text string and break them into a character array        
        foreach (char c in lines[index].ToCharArray())
        {
            //type the characters one by one
            textComponent.text += c; //go to next character
            yield return new WaitForSeconds(textSpeed); //time between each character

        }
    }

    public void Skip() 
    {
        if (textComponent.text == lines[index]) //If the current line is typed out fully
        {
            NextLine(); //go to next line
            
        }
        else
        {
            //skip to the end of the sentence
            StopAllCoroutines(); // Stop the coroutine typing out the text
            textComponent.text = lines[index]; // Immediately display the full line

        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++; //set the index of the next line
            textComponent.text = string.Empty; //delete the previous line
            StartCoroutine(TypeLine()); // start the new line
        }
        else
        {
            
            gameObject.SetActive(false); //If there are no lines left
        }

    }    

    public void ActivateLines(GameObject sourceObject)
    {
        gameObject.SetActive(true);
        // Attempt to get the TriggerDialogue component from the specified GameObject
        TriggerDialogueSC = sourceObject.GetComponent<TriggerDialogue>();

        if (TriggerDialogueSC != null)
        {
            
            DisplayActivatedLines(TriggerDialogueSC.linesToBeActive);
        }
        else
        {
            Debug.LogWarning("No DialogueData found on the specified GameObject.");
        }
    }

    private void DisplayActivatedLines(string[] activatedLines)
    {
        if (activatedLines != null && activatedLines.Length > 0)
        {
            lines = activatedLines; // Assign the new lines to the lines array
            StartDialogue(); // Start the dialogue with the new lines
        }
        else
        {
            Debug.LogWarning("Activated lines array is empty or null.");
        }


    }

    
}
