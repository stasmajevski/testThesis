using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    GameObject go = null;
    private int count = 0;
 

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        count = 1;
    }

    void Update()
    {
        if (count == 0)
        {
            if (OVRInput.Get(OVRInput.Button.One))
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
}
