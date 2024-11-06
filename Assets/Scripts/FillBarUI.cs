using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    public Image bar;
    public float fillBarValue;
    public GameManager manager;
    
    void Start()
    {

    }

    
    void Update()
    {
        fillBarValue = manager.GetHumanity();
        bar.fillAmount = fillBarValue / 100;

    }
}
