using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    GameObject go = null;
 

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
        {
            if (GameObject.FindWithTag("Start") != null)
            {
                go = GameObject.FindWithTag("Start");
            }
            if (go != null)
            {
                Destroy(go);
            }
            TriggerDialogue();
        }
    }
}
