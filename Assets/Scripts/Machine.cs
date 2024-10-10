using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject gene;

    private bool eventTriggered = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == gene && !eventTriggered)
        {
            TriggerEvent();

            eventTriggered = true;
        }
    }

    void TriggerEvent()
    {
        Destroy(gameObject);
        Destroy(gene);

        Debug.Log("Holy shit gene modification");

    }
}
