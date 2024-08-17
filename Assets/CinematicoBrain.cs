using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CinematicoBrain : MonoBehaviour
{
    public static CinematicoBrain instance { get; private set; }
    private Animator animatorCinematica;
    void Awake(){
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            this.gameObject.SetActive(true);
            animatorCinematica = this.GetComponent<Animator>();
        } else {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    public void LigarCinematica(){
        animatorCinematica.SetTrigger("cinemaAbrir");
    }

    public void DesligarCinematica(){
        animatorCinematica.SetTrigger("cinemaFechar");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Função chamada sempre que uma cena é carregada
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if(SceneLoader.IsGameScene()||SceneLoader.IsAnimScene()){
            
        }else{
            Destroy(this.gameObject);
        }
    }
}
