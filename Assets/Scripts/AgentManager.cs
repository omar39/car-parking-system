using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentManager : MonoBehaviour
{
    public NavMeshAgent agent;
    private void OnEnable() {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void ParkInEmptyPlace()
    {
        Vector3 emptyPlace = GetEmptyPlace().position;
        //transform.position = emptyPlace;
        agent.SetDestination(emptyPlace);
    }

    public Transform GetEmptyPlace()
    {
        ParkingArea[] parkingAreas = FindObjectsOfType<ParkingArea>();

        foreach(ParkingArea parkingArea in parkingAreas)
        {
            if(parkingArea.GetOccpyState() == false)
            {
                return parkingArea.transform;
            }
        }
        return null;
    }
}
