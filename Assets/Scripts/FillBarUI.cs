using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    public Image bar;
    public float fillBarAmount;
    public GameManager manager;
    public bool test;
    void Start()
    {
        fillBarAmount = manager.humanity;
    }

    void TestTest()
    {
        if (test)
        {
            fillBarAmount = fillBarAmount + 17/100;
            Debug.Log("OUSBGNISJEÞTÝGSET");
        }
    }
    void Update()
    {
        TestTest();
        bar.fillAmount = fillBarAmount / 100;
       

    }
}
