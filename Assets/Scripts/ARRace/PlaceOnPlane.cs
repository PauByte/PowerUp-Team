using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    public GameObject prefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedObject; //guardamos el jugador

    void Awake()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (spawnedObject != null) return; // ya existe → no crear más

        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
        }
    }
}