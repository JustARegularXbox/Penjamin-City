using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class GameManager : MonoBehaviour
{
    private List<GameObject> spawnedCreatures = new List<GameObject>();
    private List<GameObject> spawnedPreviews = new List<GameObject>();

    public int[] orders = { 3, 1, 6, 4, 2, 5 };
    public int orderCounter = 1;
    private int createdCreature;

    private int humanity = 0;

    public bool modInt = false;
    public bool modSpd = false;
    public bool modPwr = false;
    public bool modEco = false;

    private GameObject reqPre;
    private GameObject reqPrev;

    public GameObject[] prefabsCre = new GameObject[6];

    public GameObject[] prefabsPre = new GameObject[6];

    public Transform previewSpawn;
    public Transform creatureSpawn;

    void Update()
    {
        // Debug.Log(modInt);
        // Debug.Log(modSpd);
        // Debug.Log(modPwr);
        // Debug.Log(modEco);
        createdCreature = (modInt, modSpd, modPwr, modEco) switch
        {
            (true, true, false, false) => 1,
            (true, false, true, false) => 2,
            (true, false, false, true) => 3,
            (false, true, true, false) => 4,
            (false, true, false, true) => 5,
            (false, false, true, true) => 6,
            _ => 0
        };
    }

    public GameObject GetPrefab()
    {
        return reqPre = prefabsCre[createdCreature];
    }

    public GameObject GetPreview()
    {
        return reqPrev = prefabsPre[createdCreature];
    }

    public bool CheckOrder()
    {
        if (orders[orderCounter] == createdCreature)
        {
            return true;
        }
        return false;
    }

    public int GetCreature()
    {
        return createdCreature;
    }

    public void ChangeOrder()
    {
        if (orderCounter < 6)
        {
            orderCounter = orderCounter + 1;
            Debug.Log("orderCounter: "  + orderCounter);
        }
        if (humanity <= 100)
        {
            humanity = humanity + 20;
        }
        modInt = false;
        modSpd = false;
        modPwr = false;
        modEco = false;
        reqPre = null;
        reqPrev = null;
    }

    public void ResetGame()
    {
        orderCounter = 1;
        humanity = 0;
        modInt = false;
        modSpd = false;
        modPwr = false;
        modEco = false;
        reqPre = null;
        reqPrev = null;
    }

    // Helper method to instantiate a creature and keep track of it
    public void InstantiateCreature(GameObject prefab)
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
    public void ClearSpawnedCreatures()
    {
        foreach (GameObject creature in spawnedCreatures)
        {
            Destroy(creature);  // Destroy all previously spawned creatures
        }
        spawnedCreatures.Clear();  // Clear the list
    }

    ///////////////////////////////////////////////////////////////////PREVIEWS/////////////////////////////////////////////////////////////////////////////////////////////
    public void InstantiatePreview(GameObject prefab)
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

    public void ClearSpawnedPreviews()
    {
        foreach (GameObject preview in spawnedPreviews)
        {
            Destroy(preview);  // Destroy all previously spawned creatures
        }
        spawnedPreviews.Clear();  // Clear the list
    }
}
