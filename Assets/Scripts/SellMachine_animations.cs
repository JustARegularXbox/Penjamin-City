using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class SellMachine_animations : MonoBehaviour
{
    private sell_anim_point sell_point;
    private sell_anim_trapdoor anim_Trapdoor;

    public void Sold_animation()
    {
        sell_point.Move_Point();
    }

    public void Kill_animation()
    {
        anim_Trapdoor.Close();
    }

    void Update()
    {
       
    }
}
