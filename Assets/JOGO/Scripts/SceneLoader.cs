using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public void LoadScene() {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 4 || index != 8) {
            SceneManager.LoadScene((index+1), LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene((index-3), LoadSceneMode.Single);
        }
    }
    public static bool IsGameScene(){
        
        return SceneManager.GetActiveScene().name.StartsWith("Cena");
        
    }
}