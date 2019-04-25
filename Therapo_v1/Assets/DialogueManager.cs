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
    private Queue<AudioSource> _audioSources;

    private int _count;


    private AudioSource[] _allAudioSources;

    void StopAllAudio()
    {
        AudioSource backgroundMusic = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        _allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        if (_allAudioSources != null)
        {
            List<AudioSource> list = new List<AudioSource>(_allAudioSources);
            list.Remove(backgroundMusic);
            _allAudioSources = list.ToArray();
        }

        if (_allAudioSources != null)
            foreach (AudioSource audioS in _allAudioSources)
            {
                audioS.Stop();
            }
    }


    // Use this for initialization
    private void Start()
    {
        _sentences = new Queue<string>();
        _audioSources = new Queue<AudioSource>();
        conButoon.gameObject.SetActive(false);
    }

    private void Update()
    {
        //  if (OVRInput.GetUp(OVRInput.Button.One))
        if (Input.GetKeyUp(KeyCode.T))
        {
            _count++;
            if (_count > 1)
            {
                StopAllAudio();
                DisplayNextSentence();
                PlayNextAudioSource();

            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogCanvas.gameObject.SetActive(true);
        conButoon.gameObject.SetActive(true);
        nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (var sentence in dialogue.sentences) _sentences.Enqueue(sentence);
        foreach (var audioSource in dialogue.audioSources) _audioSources.Enqueue(audioSource);

        StopAllAudio();
        DisplayNextSentence();
        PlayNextAudioSource();
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

    public void PlayNextAudioSource()
    {
        var audioSource = _audioSources.Dequeue();
        Debug.Log(audioSource);
        audioSource.Play();
    }

    public void EndDialogue()
    {
        dialogCanvas.gameObject.SetActive(false);
    }
}