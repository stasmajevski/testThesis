using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{


    [HideInInspector] public bool InReach;
    public string Character = "e";

    // UI SETTINGS
    [Header("UI Settings")]
    [Tooltip("The image or text that will be shown whenever the player is in reach of the door.")]
    public GameObject TextPrefab; // A text element to display when the player is in reach of the door
    [HideInInspector] public GameObject TextPrefabInstance; // A copy of the text prefab to prevent data corruption
    [HideInInspector] public bool TextActive;



    public float interactDistance = 5f;

    // Update is called once per frame
    void Update()
    {


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.tag == "Door")
            {
                InReach = true;

                // Display the UI element when the player is in reach of the door
                if (TextActive == false && TextPrefab != null)
                {
                    TextPrefabInstance = Instantiate(TextPrefab);
                    TextActive = true;
                    TextPrefabInstance.transform.SetParent(transform, true); // Make the player the parent object of the text element
                }

                if (Input.GetKey("e"))
                {

                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                }
            }
        else
        {
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive)
            {
                DestroyImmediate(TextPrefabInstance);
                TextActive = false;
            }
        }
    }

        else
        {
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive)
            {
                DestroyImmediate(TextPrefabInstance);
                TextActive = false;
            }
        }


    }
}