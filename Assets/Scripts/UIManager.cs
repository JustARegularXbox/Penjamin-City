using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject gameObj;
    private GameObject[] textObjs = new GameObject[7];
    private GameManager gameManager;
    // Start is called before the first frame update
    void Update()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
        textObjs[0] = GameObject.FindWithTag("customer");
        textObjs[1] = GameObject.FindWithTag("subject");
        textObjs[2] = GameObject.FindWithTag("description");
        textObjs[3] = GameObject.FindWithTag("name");
        textObjs[4] = GameObject.FindWithTag("mod");
        textObjs[5] = GameObject.FindWithTag("job");
        textObjs[6] = GameObject.FindWithTag("sellto");
    }

    // Update is called once per frame
    public void UpdateText()
    {
        TextMeshProUGUI customer = textObjs[0].GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI subject = textObjs[1].GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI description = textObjs[2].GetComponent<TextMeshProUGUI>();


        customer.text = gameManager.orderArray[gameManager.GetOrderCounter()].customer;
        subject.text = gameManager.orderArray[gameManager.GetOrderCounter()].subject;
        description.text = gameManager.orderArray[gameManager.GetOrderCounter()].description;

        if (textObjs[3] != null)
        {
            TextMeshProUGUI name = textObjs[3].GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI mod = textObjs[4].GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI job = textObjs[5].GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI sellto = textObjs[6].GetComponent<TextMeshProUGUI>();
            name.text = gameManager.soldArray[gameManager.GetCreature()].name;
            mod.text = gameManager.soldArray[gameManager.GetCreature()].mod;
            job.text = gameManager.soldArray[gameManager.GetCreature()].job;
            sellto.text = gameManager.soldArray[gameManager.GetCreature()].customer;
        }
    }
}
