using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueMessage;
    public Text nameText;
    public GameObject dialogCanvas;

    public Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        dialogCanvas.gameObject.SetActive(true);
	}

    public void StartDialogue (Dialogue dialogue)
    {

        dialogCanvas.gameObject.SetActive(true);

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
