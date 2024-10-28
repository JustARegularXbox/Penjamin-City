using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureAnimation : MonoBehaviour
{
    public SkinnedMeshRenderer eyesMeshRenderer;
    public SkinnedMeshRenderer mouthMeshRenderer;
    public SkinnedMeshRenderer bodyMeshRenderer;

    [SerializeField] private float animationSpeed;
    private int weightValue;
    private void Start()
    {
        animationSpeed = 1;
        SadCreatureAnimation();
        //PetCreatureAnimation();
    }

    private void SetBlendShapeWeight(int index, float weight)
    {
        eyesMeshRenderer.SetBlendShapeWeight(index, weight);        
        mouthMeshRenderer.SetBlendShapeWeight(index, weight);
        bodyMeshRenderer.SetBlendShapeWeight(index, weight);
    }

    public void SadCreatureAnimation()
    {
        for (int weightValue = 0; weightValue <= 100; weightValue += 1/10)
        {
            SetBlendShapeWeight(0, weightValue * animationSpeed);
            //animationSpeed += 1;
            Debug.Log("loop");
        }
        
        
    }

    public void PetCreatureAnimation()
    {
        SetBlendShapeWeight(1, 100); 
    }
}
