using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingAreaManager : MonoBehaviour
{
    public GameObject[] cars;
    private ParkingArea[] parkingAreas;
    void OnEnable()
    {
        parkingAreas = FindObjectsOfType<ParkingArea>();
        GenerateOccupiedPlaces();
    }

    private void GenerateOccupiedPlaces()
    {
        int parkingAreasCount = parkingAreas.Length;
        int nonOccupiedPlaceIndex = Random.Range(0, parkingAreasCount + 1);
        print("Excluded place: " + nonOccupiedPlaceIndex.ToString());

        for(int i = 0;i < parkingAreasCount;++i)
        {
            if(nonOccupiedPlaceIndex == i) continue;

            parkingAreas[i].OccupyWithObject(cars);
        }
    }
}
