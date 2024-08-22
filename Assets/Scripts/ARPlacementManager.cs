using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARPlacementManager : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject simulator;
    private ARRaycastManager arRaycaster;
    bool placementPosIsValid = true;
    List<ARRaycastHit> hits;

    // camera positing refernce to position the indicator and objects
    private Pose placementPos;
    void OnEnable()
    {
        arRaycaster = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPos();
        UpdatePlacementIndicator();
    }
     public void PlaceObject()
    {
        simulator.SetActive(true);
        simulator.transform.SetPositionAndRotation(placementPos.position, placementPos.rotation);
    }
    private void UpdatePlacementPos()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        
        placementPosIsValid = hits.Count > 0;

        if(placementPosIsValid)
        {
            placementPos = hits[0].pose;
        }
    }
    private void UpdatePlacementIndicator()
    {
        if(placementPosIsValid)
        {
            placementIndicator.SetActive(true);
            transform.SetPositionAndRotation(placementPos.position, placementPos.rotation);
        }
        else 
        {
            placementIndicator.SetActive(false);
        }
    }
}
