using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ModCheck : MonoBehaviour
{
    public static ModCheck instance;

    

    private bool intelligence;
    private bool power;
    private bool speed;
    private bool ecoFriendly;

    public GameObject intEcoCreature;   // Prefab for eco-friendly intelligent creature
    public GameObject intSpdCreature;   // Prefab for speed-focused intelligent creature
    public GameObject intSpdPreview;
    public GameObject intEcoPreview;

    public Transform previewSpawn;
    public Transform creatureSpawn;

    private List<GameObject> spawnedCreatures = new List<GameObject>();  // Keep track of spawned creatures
    private List<GameObject> spawnedPreviews = new List<GameObject>();


    private void Awake()
    {
        // Ensure there is only one instance of the manager (singleton pattern)
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateCombination(string tag, bool state)
    {
        switch (tag)
        {
            case "intelligence":
                intelligence = state;
                break;
            case "ecoFriendly":
                ecoFriendly = state;
                break;
            case "speed":
                speed = state;
                break;
            case "power":
                power = state;
                break;
        }
        Debug.Log("create combi");
    }

    public void Creaturepreview()
    {
        ClearSpawnedPreviews();
        if (intelligence)
        {
            if (speed)
            {
                InstantiatePreview(intSpdPreview);
                Debug.Log("spdint");
            }
            else if (ecoFriendly)
            {
                InstantiatePreview(intEcoPreview);
                Debug.Log("ecoint");
            }
        }

    }
    public void createCreature()
    {
        // Clear previous creatures before creating new ones
        ClearSpawnedCreatures();

        if (intelligence)
        {
            if (speed)
            {
                InstantiateCreature(intSpdCreature); // Spawn speed-focused creature
            }
            else if (ecoFriendly)
            {
                InstantiateCreature(intEcoCreature); // Spawn eco-friendly creature
            }
        }
    }

    // Helper method to instantiate a creature and keep track of it
    private void InstantiateCreature(GameObject prefab)
    {
        ClearSpawnedPreviews();
        if (prefab != null)
        {
            
            GameObject newCreature = Instantiate(prefab, creatureSpawn.position, creatureSpawn.rotation); 
            spawnedCreatures.Add(newCreature);  //for list

            MeshCollider meshC = newCreature.AddComponent<MeshCollider>();
            meshC.convex = true;

            newCreature.AddComponent<XRGrabInteractable>(); //make it grabable
            
        }
        else
        {
            Debug.LogError("no prefab assigned!!");
        }
    }

    // Method to clear previous spawned creatures before creating new ones
    private void ClearSpawnedCreatures()
    {
        foreach (GameObject creature in spawnedCreatures)
        {
            Destroy(creature);  // Destroy all previously spawned creatures
        }
        spawnedCreatures.Clear();  // Clear the list
    }


    ///////////////////////////////////////////////////////////////////PREVIEWS/////////////////////////////////////////////////////////////////////////////////////////////
    private void InstantiatePreview(GameObject prefab)
    {
        if (prefab != null)
        {
            
            GameObject newPreview = Instantiate(prefab, previewSpawn.position, previewSpawn.rotation); // Spawn at (0, 0, 0) with no rotation
            spawnedPreviews.Add(newPreview);  // Keep track of spawned creature
            newPreview.AddComponent<spinObject>(); //make the preview spin around
        }
        else
        {
            Debug.LogError("no prefab assigned!!");
        }
    }

    private void ClearSpawnedPreviews()
    {
        foreach (GameObject preview in spawnedPreviews)
        {
            Destroy(preview);  // Destroy all previously spawned creatures
        }
        spawnedPreviews.Clear();  // Clear the list
    }
}