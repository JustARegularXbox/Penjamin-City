using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Threading.Tasks;


public class GameManager : MonoBehaviour
{
    private List<GameObject> spawnedCreatures = new List<GameObject>();
    private List<GameObject> spawnedPreviews = new List<GameObject>();

    public int[] orders = { 3, 1, 6, 4, 2, 5 };
    public int orderCounter = 1;
    private int createdCreature;

    public int humanity = 0;

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

    public OrderList orderList;
    public Order[] orderArray = new Order[6];

    public SoldList soldList;
    public Sold[] soldArray = new Sold[6];

    
    private GameObject uiObj;
    private UIManager uiManager;

    void Awake()
    {
        LoadOrders();
        LoadSolds();
        uiObj = GameObject.FindWithTag("UI");
        uiManager = uiObj.GetComponent<UIManager>();
    }

    void Update()
    {
        uiManager.UpdateText();
        //Debug.Log(modInt);
        //Debug.Log(modSpd);
        //Debug.Log(modPwr);
        //Debug.Log(modEco);
        createdCreature = (modInt, modSpd, modPwr, modEco) switch
        {
            (true, true, false, false) => 0,
            (true, false, true, false) => 1,
            (true, false, false, true) => 2,
            (false, true, true, false) => 3,
            (false, true, false, true) => 4,
            (false, false, true, true) => 5,
            _ => -1
        };

        //Debug.Log(createdCreature);
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
            Debug.Log("orderCounter: " + orderCounter);
        }
        if (humanity <= 100)
        {
            humanity = humanity + 17;
        }
        modInt = false;
        modSpd = false;
        modPwr = false;
        modEco = false;
        reqPre = null;
        reqPrev = null;
        uiManager.UpdateText();
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

    [System.Serializable]
    public class Order
    {
        public string customer;
        public string subject;
        public string description;
    }

    [System.Serializable]
    public class OrderList
    {
        public Order[] orders;
    }

    [System.Serializable]
    public class Sold
    {
        public string customer;
        public string mod;
        public string name;
        public string job;
    }
    public class SoldList
    {
        public Sold[] solds;
    }
    

    public void LoadOrders()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("orders");

        if (jsonFile != null)
        {
            orderList = JsonUtility.FromJson<OrderList>(jsonFile.text);

            Debug.Log(orderList);

            if (orderList.orders == null)
            {
                Debug.LogError("JSON file parsed, but 'orders' is null. Check JSON structure.");
            }

            foreach (Order order in orderList.orders)
            {
                Debug.Log($"Customer: {order.customer}, Subject: {order.subject}, Description: {order.description}");
                orderArray[orderCounter] = order;
            }
        }
        else
        {
            Debug.LogError("Could not find orders.json in Resources folder!");
        }
    }

    public void LoadSolds()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("solds");

        if (jsonFile != null)
        {
            soldList = JsonUtility.FromJson<SoldList>(jsonFile.text);

            if (soldList.solds == null)
            {
                Debug.LogError("JSON file parsed, but 'solds' is null. Check JSON structure.");
            }

            foreach (Sold sold in soldList.solds)
            {
                soldArray[orderCounter] = sold;
            }
        }
        else
        {
            Debug.LogError("Could not find solds.json in Resources folder!");
        }
    }
    
}

