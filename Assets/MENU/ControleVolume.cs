using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public float volumeGeral, volumeMusica, volumeES;

    public void VolumeGeral(float volume) {
        volumeGeral = volume;
        PlayerPrefs.SetInt("ConfiguracoesAlteradas", 1);
        PlayerPrefs.SetFloat("volumeGeral",volume);
        print(PlayerPrefs.GetFloat("volumeGeral"));
    }

    public void VolumeMusica(float volume) {
        volumeMusica = volume;
        PlayerPrefs.SetInt("ConfiguracoesAlteradas", 1);
        PlayerPrefs.SetFloat("volumeMusica", volume);
        print(PlayerPrefs.GetFloat("volumeMusica"));
    }

    public void VolumeEfeitoSonoro(float volume) {
        volumeES = volume;
        PlayerPrefs.SetInt("ConfiguracoesAlteradas", 1);
        PlayerPrefs.SetFloat("volumeEfeitoSonoro", volume);
        print(PlayerPrefs.GetFloat("volumeEfeitoSonoro"));
    }
}