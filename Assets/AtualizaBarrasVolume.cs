using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtualizaBarrasVolume : MonoBehaviour
{

    [SerializeField] private Slider sliderGeral;
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderEfeitosSonoros;
    void Start(){
        print("Configurações alteradas: " + PlayerPrefs.GetInt("ConfiguracoesAlteradas"));
        if(PlayerPrefs.GetInt("ConfiguracoesAlteradas")!=1){
            print("Tornando valor volume padrão");
            PlayerPrefs.SetFloat("volumeGeral", 0.5f);
            PlayerPrefs.SetFloat("volumeMusica", 0.5f);
            PlayerPrefs.SetFloat("volumeEfeitoSonoro", 0.5f);
        }
        sliderGeral.value = PlayerPrefs.GetFloat("volumeGeral");
        sliderMusica.value = PlayerPrefs.GetFloat("volumeMusica");
        sliderEfeitosSonoros.value = PlayerPrefs.GetFloat("volumeEfeitoSonoro");
    }
}
