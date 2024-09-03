using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinidorDificuldades : MonoBehaviour {


    private SceneLoaderGame sceneLoader;

    void Start(){
        sceneLoader = FindObjectOfType<SceneLoaderGame>();
    }
    public void AlterarDificuldadePraFacil(){
        PlayerPrefs.SetInt("Dificuldade", 0);
        StartCoroutine(sceneLoader.LoadScene());  
    }
    public void AlterarDificuldadePraMedio(){
        PlayerPrefs.SetInt("Dificuldade", 1);
        StartCoroutine(sceneLoader.LoadScene());  
    }
    public void AlterarDificuldadePraDificil(){
        PlayerPrefs.SetInt("Dificuldade", 2);      
        StartCoroutine(sceneLoader.LoadScene());  
    }
}