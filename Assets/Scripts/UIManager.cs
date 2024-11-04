using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject gameObj;
    private GameObject[] textObjs = new GameObject[3];
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
        textObjs[0] = GameObject.FindWithTag("customer");
        textObjs[1] = GameObject.FindWithTag("subject");
        textObjs[2] = GameObject.FindWithTag("description");
    }

    // Update is called once per frame
    public void UpdateText()
    {
        TextMeshProUGUI customer = textObjs[0].GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI subject = textObjs[1].GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI description = textObjs[2].GetComponent<TextMeshProUGUI>();

        customer.text = gameManager.orderArray[gameManager.orderCounter].customer;
        subject.text = gameManager.orderArray[gameManager.orderCounter].subject;
        description.text = gameManager.orderArray[gameManager.orderCounter].description;
    }
}
