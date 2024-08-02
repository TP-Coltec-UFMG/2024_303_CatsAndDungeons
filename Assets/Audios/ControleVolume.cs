using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public float volumeGeral, volumeMusica, volumeES;

    public void VolumeGeral(float volume) {
        volumeGeral = volume;

        PlayerPrefs.SetFloat("volumeGeral",volume);
        // AudioListener.volume = volumeGeral;

        print(PlayerPrefs.GetFloat("volumeGeral"));
    }

    public void VolumeMusica(float volume) {
        volumeMusica = volume;

        PlayerPrefs.SetFloat("volumeMusica", volume);
        // GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        // for(int i = 0; i < Musicas.Length; i++){
        //     Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        // }
        print(PlayerPrefs.GetFloat("volumeMusica"));
    }

    public void VolumeEfeitoSonoro(float volume) {
        volumeES = volume;
        PlayerPrefs.SetFloat("volumeEfeitoSonoro", volume);
        //GameObject[] ESs = GameObject.FindGameObjectsWithTag("EfeitoSonoro");

        // for(int i = 0; i < ESs.Length; i++){
        //     ESs[i].GetComponent<AudioSource>().volume = volumeES;
        // }

        print(PlayerPrefs.GetFloat("volumeEfeitoSonoro"));
    }
}