using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject _go;
    private int _count;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        _count = 1;
    }

    private void Update()
    {
        if (_count == 0)
            if (OVRInput.Get(OVRInput.Button.One)) 
            {
                if (GameObject.FindWithTag("Start") != null) _go = GameObject.FindWithTag("Start");
                    if (_go != null) Destroy(_go);
                    TriggerDialogue();
            }
    }
}