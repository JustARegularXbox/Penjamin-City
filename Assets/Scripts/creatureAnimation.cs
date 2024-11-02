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
        //SadCreatureAnimation();
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
        SetBlendShapeWeight(0, 100);

    }

    public void PetCreatureAnimation()
    {
        SetBlendShapeWeight(1, 100); 
    }

    public void neutralCreatureAnimation()
    {
        SetBlendShapeWeight(0, 0);
        SetBlendShapeWeight(1, 0);
        SetBlendShapeWeight(2, 0);
    }
}
