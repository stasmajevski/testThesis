using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 20)] public string[] sentences;
    public AudioSource[] audioSources;
}