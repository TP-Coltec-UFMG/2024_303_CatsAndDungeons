using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinidorDificuldades : MonoBehaviour {
    public void AlterarDificuldadePraFacil(){
        PlayerPrefs.SetInt("Dificuldade", 0);
    }
    public void AlterarDificuldadePraMedio(){
        PlayerPrefs.SetInt("Dificuldade", 1);
    }
    public void AlterarDificuldadePraDificil(){
        PlayerPrefs.SetInt("Dificuldade", 2);        
    }
}