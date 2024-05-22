using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public float volumeGeral, volumeMusica, volumeES;

    public void VolumeGeral(float volume) {
        volumeGeral = volume;
        AudioListener.volume = volumeGeral;
    }

    public void VolumeMusica(float volume) {
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Musicas.Length; i++){
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }
    }

    public void VolumeEfeitoSonoro(float volume) {
        volumeES = volume;
        GameObject[] ESs = GameObject.FindGameObjectsWithTag("EfeitoSonoro");
        for(int i = 0; i < ESs.Length; i++){
            ESs[i].GetComponent<AudioSource>().volume = volumeES;
        }
    }
}