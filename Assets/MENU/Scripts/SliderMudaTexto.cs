using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderMudaTexto : MonoBehaviour{

    private TMP_Text _Text;
    private Slider _Slider;
    private string tipoVolume;


    void Start(){
        _Text = this.gameObject.GetComponent<TMP_Text>();
        _Slider = this.GetComponentInChildren<Slider>();


        tipoVolume = _Text.text;
        _Text.text = tipoVolume + " " + Mathf.Round(_Slider.value * 100);
    }
    public void atualizaTexto(){
        _Text.text = tipoVolume + " "+ Mathf.Round(_Slider.value*100);
    }
}
