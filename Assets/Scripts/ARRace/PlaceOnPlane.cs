using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class PlaceOnPlane : MonoBehaviour
{
    public GameObject prefab;
    public TextMeshProUGUI instructionText;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private ARSession arSession;

    private List<ARRaycastHit> hits =
        new List<ARRaycastHit>();

    private GameObject spawnedObject;
    public AudioSource backgroundMusic;

    void Awake()
    {
        raycastManager =
            FindFirstObjectByType<ARRaycastManager>();

        planeManager =
            FindFirstObjectByType<ARPlaneManager>();

        arSession =
            FindFirstObjectByType<ARSession>();
    }

    void Start()
    {
        if (arSession != null)
        {
            arSession.Reset();
        }

        if (planeManager != null)
        {
            planeManager.enabled = true;
        }
    }

    void Update()
    {
        if (spawnedObject != null)
            return;

        bool planeDetected =
            planeManager.trackables.count > 0;

        if (instructionText != null)
        {
            if (planeDetected)
            {
                instructionText.text =
                    "Tap screen to place car";
            }
            else
            {
                instructionText.text =
                    "Move phone to scan surface";
            }
        }

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(
            touch.position,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            spawnedObject =
                Instantiate(
                    prefab,
                    hitPose.position,
                    hitPose.rotation);

            // ocultar texto
            if (instructionText != null)
            {
                instructionText.gameObject
                    .SetActive(false);
            }

            // ocultar planos
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            // detener nuevos planos
            planeManager.enabled = false;

            // EMPEZAR PARTIDA
            ARRaceGameManager gameManager =
                FindFirstObjectByType<ARRaceGameManager>();

            if (gameManager != null)
            {
                gameManager.StartGame();
            }

            // música            
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
    }
}