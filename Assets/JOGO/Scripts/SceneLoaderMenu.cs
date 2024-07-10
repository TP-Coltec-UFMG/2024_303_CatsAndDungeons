using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMenu : MonoBehaviour
{
    public void LoadScene() {
        Time.timeScale = 1;
        print("Tentei coisar");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
