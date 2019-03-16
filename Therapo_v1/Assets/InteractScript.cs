using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    [HideInInspector] public bool InReach;
    public string Character = "e";

    // UI SETTINGS
    [Header("UI Settings")]
    [Tooltip("The image or text that will be shown whenever the player is in reach of the door.")]
    public GameObject TextPrefabInstance; // A text element to display when the player is in reach of the door
    [HideInInspector] public GameObject TextPrefabInstanceCopy; // A copy of the text prefab to prevent data corruption
    [HideInInspector] public bool TextActive;

    public float interactDistance = 5f;

    private void Start()
    {
        TextPrefabInstance.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //  TextPrefab.GetComponent<Renderer>().enabled = false;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Debug.Log("BLA " + hit.collider.gameObject);

            if (hit.collider.tag == "Door")
            {
                Debug.Log("REACHED");
                InReach = true;

                // Display the UI element when the player is in reach of the door
                if (TextActive == false)
                {
                    TextPrefabInstance.gameObject.SetActive(true);
                    //   TextPrefabInstance = Instantiate(TextPrefab);
                    //     TextPrefabInstance.transform.localScale = new Vector3(0, 0, -312);
                    //     Destroy(TextPrefab);
                    TextActive = true;
                    //  TextPrefabInstance.transform.SetParent(transform, true); // Make the player the parent object of the text element
                }

                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                    Destroy(hit.collider.GetComponent<BoxCollider>());
                    if (TextActive)
                    {
                        TextPrefabInstance.gameObject.SetActive(false);
                        TextActive = false;
                    }
                }
            }
        }

        else
        {
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive)
            {
                TextPrefabInstance.gameObject.SetActive(false);
                TextActive = false;
            }
        }


    }
}