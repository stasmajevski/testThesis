using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    [HideInInspector] public bool InReach;

    // UI SETTINGS
    [Header("UI Settings")]
    [Tooltip("The image or text that will be shown whenever the player is in reach of the door.")]
    public GameObject TextPrefabInstance; // A text element to display when the player is in reach of the door

    [HideInInspector] public GameObject TextPrefabInstanceCopy; // A copy of the text prefab to prevent data corruption
    [HideInInspector] public bool TextActive;
    public GameObject TransparentWall;
    public GameObject TransparentWallSecond;
    public float interactDistance = 5f;

    private GameObject[] gameObjects;
    private bool musicIsPlaying;
    private int xClicked;

    private Queue<GameObject> _walls;

    private void Start()
    {
        TextPrefabInstance.gameObject.SetActive(false);
        TransparentWallSecond.gameObject.SetActive(false);

        _walls.Enqueue(TransparentWall);
        _walls.Enqueue(TransparentWallSecond);

        TextActive = true;
        musicIsPlaying = true;
        xClicked = 0;

    }

    // Update is called once per frame
    private void Update()
    {
        //TransparentWallSecond.gameObject.SetActive(true);

        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.tag == "Door")
            {
                Debug.Log("REACHED");
                InReach = true;
                gameObjects = GameObject.FindGameObjectsWithTag("Dialogue");

                // Display the UI element when the player is in reach of the door
                if (TextActive)
                {
                    if (gameObjects.Length == 0)
                    {
                        TextPrefabInstance.GetComponentInChildren<Text>().text = "Ukse avamiseks vajuta \"B\"";
                        if (OVRInput.Get(OVRInput.Button.Two))
                        {
                            hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
                            //    Destroy(hit.collider.GetComponent<BoxCollider>());
                            TextPrefabInstance.gameObject.SetActive(false);
                            TextActive = false;
                        }
                    }
                    else
                    {
                        TextPrefabInstance.GetComponentInChildren<Text>().text = "Räägi doktoriga";
                    }

                    TextPrefabInstance.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            InReach = false;
            TextPrefabInstance.gameObject.SetActive(false);
        }

        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            Debug.Log("pressed");
            if (TransparentWall.activeSelf)
            {
                TransparentWallSecond.gameObject.SetActive(true);
                TransparentWall.gameObject.SetActive(false);
            }
            else
            {
                TransparentWallSecond.gameObject.SetActive(false);
            }

        }

        if (!OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) &&
            !OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) return;
        if (!musicIsPlaying)
        {
            GetComponent<AudioSource>().Play();
            musicIsPlaying = true;
        }
        else
        {
            GetComponent<AudioSource>().Pause();
            musicIsPlaying = false;
        }
    }
}