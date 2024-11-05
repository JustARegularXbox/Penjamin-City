using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModCheck : MonoBehaviour
{
    public static ModCheck instance;
    public GameObject gameObj;

    public GameManager gameManager;

    private GameObject prefab;
    private GameObject preview;
    private TriggerDialogue DialogueSC;
    private void Awake()
    {
        gameObj = GameObject.FindWithTag("GameManager");
        gameManager = gameObj.GetComponent<GameManager>();
        // Ensure there is only one instance of the manager (singleton pattern)
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        prefab = gameManager.GetPrefab();
        preview = gameManager.GetPreview();
        DialogueSC = GetComponent<TriggerDialogue>();
    }

    public void CreaturePreview()
    {
        gameManager.ClearSpawnedPreviews();
        gameManager.InstantiatePreview(preview);

    }
    public void CreateCreature()
    {
        gameManager.ClearSpawnedCreatures();
        gameManager.InstantiateCreature(prefab);
        DialogueSC.SendLines();
    }

}