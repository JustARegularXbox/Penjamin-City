using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    public Image bar;
    public float fillBarAmount;
    public GameManager manager;
    
    void Start()
    {
        fillBarAmount = manager.humanity;
    }

    
    void Update()
    {
        
        bar.fillAmount = fillBarAmount / 100;
       

    }
}
