using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueMessage;
    public Text nameText;
    public GameObject dialogCanvas;
    public Button conButoon;

    private Queue<string> _sentences;
    private int _count;

    // Use this for initialization
    private void Start()
    {
        _sentences = new Queue<string>();
        conButoon.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            _count++;
            if (_count > 1) DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogCanvas.gameObject.SetActive(true);
        conButoon.gameObject.SetActive(true);
        nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        var sentence = _sentences.Dequeue();
        dialogueMessage.text = sentence;
    }

    public void EndDialogue()
    {
        dialogCanvas.gameObject.SetActive(false);
    }
}