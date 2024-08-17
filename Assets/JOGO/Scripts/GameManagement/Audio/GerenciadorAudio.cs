using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GerenciadorAudio : MonoBehaviour
{

    [SerializeField] Som[] musicas;
    [SerializeField] Som[] efeitosSonoros;
    [SerializeField] AudioSource tocadorMusica; 
    [SerializeField] AudioSource tocadorSFX;
    private bool isFading = false;
    private const float volumeMusicaReduzido = 0.005f;
    //private const float volumeMusicaPadrao = 0.1f;

    public static GerenciadorAudio instance { get; private set; }
    //Para usar o Gerenciador de �udio, use GerenciadorAudio.instance.Funcao(); ou GerenciadorAudio.instance.atributo;
    
    
    
    void Awake() //
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        
    }

    public void TocarMusica(string nome) {
        Som musicaPraTocar = Array.Find(musicas, x => x.nome == nome);

        if (musicaPraTocar == null) {
            print("Musica nao encontrada");
        } else {
            tocadorMusica.clip = musicaPraTocar.audio;
            StartCoroutine(FadeIn(tocadorMusica, 3f));
        }
    }

    public void TocarSFX(string nome) {
        Som somPraTocar = Array.Find(efeitosSonoros, x => x.nome == nome);

        if (somPraTocar == null) {
            print("Som nao encontrado");
        } else {
            if (nome == "Tomar Dano" || nome == "Morte") {
                tocadorMusica.volume = volumeMusicaReduzido * PlayerPrefs.GetFloat("volumeMusica") * PlayerPrefs.GetFloat("volumeGeral");
                tocadorSFX.clip = somPraTocar.audio;
                tocadorSFX.Play();
            } else {
                tocadorSFX.PlayOneShot(somPraTocar.audio);
            }
            
        }

        

    }

    public void TocarSFX(AudioClip clipe) {
        Som somPraTocar = new Som(clipe);

        if (somPraTocar == null) {
            print("Som nao encontrado");
        } else {
           tocadorSFX.PlayOneShot(somPraTocar.audio);
        }

        

    }

    void Update() {

        if (!tocadorSFX.isPlaying && !isFading) {
            tocadorMusica.volume = PlayerPrefs.GetFloat("volumeMusica") * PlayerPrefs.GetFloat("volumeGeral");
        }    
        if (tocadorSFX.isPlaying) {
            tocadorSFX.volume = PlayerPrefs.GetFloat("volumeEfeitoSonoro") * PlayerPrefs.GetFloat("volumeGeral");
        }
        //fazer código que verifica se a cena atual é de jogo ou não
        //if (tocadorMusica.isPlaying==false && SceneManager.GetActiveScene().)
    }
   
    

    public void PausarSons(){
        tocadorMusica.Pause();
        tocadorSFX.Pause();
    }

    public void ContinuarSons(){
        tocadorMusica.UnPause();
        tocadorSFX.UnPause();
    }


    public IEnumerator FadeOut (AudioSource audioSource, float DuracaoFade) {
        isFading = true;
        float volumeInicial = audioSource.volume;

        while (audioSource.volume > 0) {
            audioSource.volume -= volumeInicial * Time.deltaTime / DuracaoFade;
            yield return null;
        }

        audioSource.Pause();
        audioSource.volume = volumeInicial;
        isFading = false;
    }
    
    public IEnumerator FadeIn(AudioSource audioSource, float DuracaoFade)
    {
        isFading = true;
        float volumeInicial = 0.2f;
        float volumeTotal = PlayerPrefs.GetFloat("volumeMusica") * PlayerPrefs.GetFloat("volumeGeral");
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < volumeTotal){
            audioSource.volume += volumeInicial * Time.deltaTime / DuracaoFade;
            yield return null;
        }

        audioSource.volume = 1f;
        isFading = false;
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
        if(SceneLoader.IsGameScene()){
            this.TocarMusica("Trilha Dungeon Loop");   
        }  else{
            this.PausarSons();
        }
    }
}


