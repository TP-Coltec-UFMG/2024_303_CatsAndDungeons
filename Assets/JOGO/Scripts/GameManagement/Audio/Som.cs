using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Som
{
    public string nome;
    public AudioClip audio;
    public Som(AudioClip audio){
        this.audio = audio;
    }
}
