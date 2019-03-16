using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueMessage;
    public Text nameText;
    public GameObject dialogCanvas;
    public Button conButoon;

    private Queue<string> sentences;
    private int count = 0;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        conButoon.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            count++;
            if(count > 1)
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        dialogCanvas.gameObject.SetActive(true);
        conButoon.gameObject.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueMessage.text = sentence;
    }

    public void EndDialogue()
    {
        dialogCanvas.gameObject.SetActive(false);
    }
}
