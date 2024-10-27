using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject placeToPlace;
    public GameObject spawnPoint;

    void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 placeCurrentPos = placeToPlace.transform.position;

        float distance = Vector3.Distance(currentPos, placeCurrentPos);
        //Debug.Log(distance);

        if (distance < 0.3)
        {
            spawnPoint.GetComponent<Spawner>().SpawnAtPoint();
            Destroy(gameObject);
        }
    }
}
