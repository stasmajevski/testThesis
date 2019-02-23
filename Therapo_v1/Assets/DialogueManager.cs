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

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
       // dialogCanvas.gameObject.SetActive(true);
        // dialogCanvas.gameObject.SetActive(false);
        //   dialogueMessage.gameObject.SetActive(false);
        //   nameText.gameObject.SetActive(false);
        //   conButoon.gameObject.SetActive(false);
    }

  /*  private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
          //  conButoon.onClick.Invoke();

            // conButoon.onClick.Invoke();
            // DisplayNextSentence();
            Debug.Log("TEST");
        }
    }*/

    public void StartDialogue (Dialogue dialogue)
    {
        dialogCanvas.gameObject.SetActive(true);
       /* dialogueMessage.gameObject.SetActive(true);
        conButoon.gameObject.SetActive(true);
        nameText.gameObject.SetActive(true);*/
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        Debug.Log(sentences.Count);
            if (sentences.Count == 0)
            {
               // EndDialogue();
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
