using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GerenciadorAudio : MonoBehaviour
{

    [SerializeField] Som[] musicas;
    [SerializeField] Som[] efeitosSonoros;
    [SerializeField] AudioSource tocadorMusica; 
    [SerializeField] AudioSource tocadorSFX;

    private const float volumeMusicaReduzido = 0.005f;
    private const float volumeMusicaPadrao = 0.1f;

    public static GerenciadorAudio instance { get; private set; }
    //Para usar o Gerenciador de �udio, use GerenciadorAudio.instance.Funcao(); ou GerenciadorAudio.instance.atributo;
    
    
    // Start is called before the first frame update
    void Awake() //
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        
    }

    void Start() {
        TocarMusica("Trilha Dungeon Normal");   
    }

    public void TocarMusica(string nome) {
        Som musicaPraTocar = Array.Find(musicas, x => x.nome == nome);

        if (musicaPraTocar == null) {
            print("Musica nao encontrada");
        } else {
            tocadorMusica.clip = musicaPraTocar.audio;
            tocadorMusica.Play();
        }
    }

    public void TocarSFX(string nome) {
        Som somPraTocar = Array.Find(efeitosSonoros, x => x.nome == nome);

        if (somPraTocar == null) {
            print("Som nao encontrado");
        } else {
            if (nome == "Tomar Dano" || nome == "Morte") {
                tocadorMusica.volume = volumeMusicaReduzido;
                tocadorSFX.clip = somPraTocar.audio;
                tocadorSFX.Play();
            } else {
                tocadorSFX.PlayOneShot(somPraTocar.audio);
            }
            
        }

        

    }

    void Update() {
        if (!tocadorSFX.isPlaying) {
            tocadorMusica.volume = volumeMusicaPadrao;
        }    
    }

    public void PausarSons(){
        tocadorMusica.Pause();
        tocadorSFX.Pause();
    }

    public void ContinuarSons(){
        tocadorMusica.UnPause();
        tocadorSFX.UnPause();
    }
}
