using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sell_anim_trapdoor : MonoBehaviour
{
    public Animator trapdoorAnim;
    public SkinnedMeshRenderer trapdoorMeshRenderer;
    
    void Start()
    {
        
    }

    public void Close()
    {
        trapdoorAnim.SetBool("TrapDoorClose", true);
    }
}
