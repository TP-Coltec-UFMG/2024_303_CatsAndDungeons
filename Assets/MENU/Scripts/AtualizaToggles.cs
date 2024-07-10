using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Accessibility;
public class AtualizaToggles : MonoBehaviour
{
    private AccessibleToggle leituraTelaToggleAcess;
    private Toggle leituraTelaToggle, audioBinauralToggle, altoContrasteToggle, daltonismoToggle;
    
    // Start is called before the first frame update
    void Awake(){
        leituraTelaToggle = this.transform.GetChild(0).gameObject.GetComponent<Toggle>();
        leituraTelaToggleAcess = this.transform.GetChild(0).gameObject.GetComponent<AccessibleToggle>();
        audioBinauralToggle = this.transform.GetChild(1).gameObject.GetComponent<Toggle>();
        altoContrasteToggle = this.transform.GetChild(2).gameObject.GetComponent<Toggle>();
        daltonismoToggle = this.transform.GetChild(3).gameObject.GetComponent<Toggle>();
    }

    void Start(){

        //print("Leitor de tela " + Convert.ToBoolean(PlayerPrefs.GetInt("LeitorTela")));
        print("AudioBinaural " + Convert.ToBoolean(PlayerPrefs.GetInt("AudioBinaural")));
        print("AltoContraste " + Convert.ToBoolean(PlayerPrefs.GetInt("AltoContraste")));
        print("Daltonismo " + Convert.ToBoolean(PlayerPrefs.GetInt("Daltonismo")));

        //leituraTelaToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("LeitorTela"));
        
        //leituraTelaToggleAcess.SetToggleState(Convert.ToBoolean(PlayerPrefs.GetInt("LeitorTela")));
        audioBinauralToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("AudioBinaural"));
        altoContrasteToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("AltoContraste"));
        daltonismoToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Daltonismo"));
    }

    // Update is called once per frame
    void Update(){
        
    }
}
