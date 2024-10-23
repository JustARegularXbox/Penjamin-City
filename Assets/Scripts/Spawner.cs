using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject lilGuy;

    public GameObject placeToSpawn;

    public void SpawnAtPoint()
    {
        if (lilGuy != null && placeToSpawn != null)
        {
            Vector3 spawnPosition = placeToSpawn.transform.position;

            Instantiate(lilGuy, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Object to spawn or target object is not assigned.");
        }
    }
}
