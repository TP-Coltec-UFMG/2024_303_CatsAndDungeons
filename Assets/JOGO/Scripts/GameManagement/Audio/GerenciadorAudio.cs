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

    public static GerenciadorAudio instance { get; private set; }
    private float multiplicadorAcessivel;
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {  
        float volumeGeral = PlayerPrefs.GetFloat("volumeGeral");
        
        
         if (!tocadorSFX.isPlaying && !isFading) {
            tocadorMusica.volume = PlayerPrefs.GetFloat("volumeMusica") * volumeGeral *multiplicadorAcessivel;
         }
        if (tocadorSFX.isPlaying) {
            tocadorSFX.volume = PlayerPrefs.GetFloat("volumeEfeitoSonoro") * volumeGeral *multiplicadorAcessivel;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        multiplicadorAcessivel = SceneLoader.IsAcessibleScene()?0.3f:1;
        if (SceneLoader.IsGameScene()) {
            string cenaNome = SceneManager.GetActiveScene().name;
            string musicaParaTocar = "";
            switch (cenaNome){
                case "CenaPrincipalInicial":
                case "CenaAcessivelInicial":
                case "CenaPrincipal":
                    musicaParaTocar = "Trilha Dungeon Loop";
                    break;
                case "CenaGelo":
                case "CenaAcessivelGelo":           
                    musicaParaTocar = "Trilha Gelo Loop";
                    break;
                case "CenaFogo":
                case "CenaAcessivelFogo":
                    musicaParaTocar = "Trilha Dungeon Loop";
                    break;   
            }
            TocarMusica(musicaParaTocar);   
        } else {
            PausarSons();
        }
    }

    public void TocarMusica(string nome) 
    {
        Som musicaPraTocar = Array.Find(musicas, x => x.nome == nome);

        if (musicaPraTocar == null) {
            Debug.LogWarning("Música não encontrada: " + nome);
        } else {
            tocadorMusica.clip = musicaPraTocar.audio;
            StartCoroutine(FadeIn(tocadorMusica, 3f));
        }
    }

    public void TocarSFX(string nome) 
    {
        Som somPraTocar = Array.Find(efeitosSonoros, x => x.nome == nome);

        if (somPraTocar == null) {
            Debug.LogWarning("Som não encontrado: " + nome);
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

    public void TocarSFX(AudioClip clipe) 
    {
        if (clipe == null) {
            Debug.LogWarning("Clip de áudio não fornecido.");
        } else {
            tocadorSFX.PlayOneShot(clipe);
        }
    }

    public void PausarSons()
    {
        tocadorMusica.Pause();
        tocadorSFX.Pause();
    }

    public void ContinuarSons()
    {
        tocadorMusica.UnPause();
        tocadorSFX.UnPause();
    }

    public IEnumerator FadeOut(AudioSource audioSource, float duracaoFade) 
    {
        isFading = true;
        float volumeInicial = audioSource.volume;

        while (audioSource.volume > 0) 
        {
            audioSource.volume -= volumeInicial * Time.deltaTime / duracaoFade;
            yield return null;
        }

        audioSource.Pause();
        audioSource.volume = volumeInicial;
        isFading = false;
    }

    public IEnumerator FadeIn(AudioSource audioSource, float duracaoFade)
    {
        isFading = true;
        float volumeGeral = PlayerPrefs.GetFloat("volumeGeral");
        float multiplicadorAcessivel = SceneLoader.IsAcessibleScene()?0.3f:1;
        float volumeTotal = PlayerPrefs.GetFloat("volumeMusica") * volumeGeral*multiplicadorAcessivel;
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < volumeTotal) 
        {
            audioSource.volume += volumeTotal * Time.deltaTime / duracaoFade;
            yield return null;
        }

        audioSource.volume = volumeTotal;
        isFading = false;
    }
}
