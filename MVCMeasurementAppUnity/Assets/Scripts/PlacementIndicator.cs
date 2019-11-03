using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;

    //[SerializeField]
    private GameObject visual;

    void Start(){
        //Get the components
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        visual.SetActive(false);
    }

    void Update(){
        //shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        //If we hit an ARPlane update the position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if(!visual.activeInHierarchy)
            visual.SetActive(true);
        }
    }
}
