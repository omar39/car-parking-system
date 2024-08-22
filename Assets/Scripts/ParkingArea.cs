using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    const string CARS_ASSETS_PATH = "Cars/";
    protected bool isOccupied = false;
    GameObject randomCar;
    int assetIndex = 0;
    public void OccupyWithObject(GameObject[] cars)
    {
        assetIndex = Random.Range(0, cars.Length);

        randomCar = cars[assetIndex];
        
        GameObject instance = Instantiate(randomCar, transform);

        int sign = 0;
        while(sign == 0)
            sign = Random.Range(-1, 2);

        instance.transform.rotation = Quaternion.Euler(0, 90 * sign, 0);
        instance.transform.position = transform.position;

        isOccupied = true;
    }
    public bool GetOccpyState() => isOccupied;
}
