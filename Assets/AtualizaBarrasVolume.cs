using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtualizaBarrasVolume : MonoBehaviour
{

    [SerializeField] private Slider sliderGeral;
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderEfeitosSonoros;
    // Start is called before the first frame update
    void Start()
    {
        sliderGeral.value = PlayerPrefs.GetFloat("volumeGeral");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusica");
        sliderEfeitosSonoros.value = PlayerPrefs.GetFloat("volumeEfeitoSonoro");
    }
}
