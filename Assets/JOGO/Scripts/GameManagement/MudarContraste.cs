using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MudarContraste : MonoBehaviour {
    
    private List<string> tagsLista = new List<string> { 
        "Catito", 
        "Armadilha", 
        "EspecialImortal",
        "EspecialPontos",
        "Inimigo",
        "ParedeChao",
        "Moeda"
    };
    private static Color[] cores =
    {
        new Color(0f,1f,0.97f), // Catito
        new Color(1f, 0f, 0f),   // Armadilha
        new Color(0.5f,0f,1f),   // EspecialImortal
        new Color(1f, 1f, 0f),   // EspecialPontos
        new Color(1f,0f,0f),   // Inimigo
        new Color(0.358f, 0.358f, 0.358f),   // ParedeChao
        new Color(1f,1f,1f),   // moeda
        
    };
    private SpriteRenderer spriteRenderer;
    private TilemapRenderer tilemapRenderer;

    [SerializeField] private Material materialSpriteLitDefault;
    [SerializeField] private Material materialAltoContraste;
    private const float intensidadeCorConstraste = 4f;
    private const float intensidadeCorConstrasteTilemap = 1f;

    void Start(){

        //Para fins de teste
        //PlayerPrefs.SetInt("AltoContraste", 1);

        if (PlayerPrefs.GetInt("AltoContraste") == 1) {
            foreach (string tag in tagsLista) {
                GameObject[] listaEncontrados = GameObject.FindGameObjectsWithTag(tag);
                for (int i = 0; i < listaEncontrados.Length; i++) {
                    this.altoContraste(listaEncontrados[i]);
                }
            }
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }
    }

    public void altoContraste(GameObject objeto) {

        mudaMaterial(objeto);
        Color corSelecionada;
            try{
                corSelecionada = cores[tagsLista.IndexOf(objeto.tag)];
            }catch{
                corSelecionada = Color.green;
            }
        Debug.Log(objeto.tag + "Cor: " + corSelecionada);
        mudarCorIntensidade(corSelecionada);
        

    }


    public void mudarCorIntensidade(Color cor) {
        if (spriteRenderer != null && spriteRenderer.material.HasProperty("_Color")) {
            spriteRenderer.material.SetColor("_Color", cor);
            spriteRenderer.material.SetFloat("_Intensity", intensidadeCorConstraste);
        }
        if (tilemapRenderer != null && tilemapRenderer.material.HasProperty("_Color")) {
            tilemapRenderer.material.SetColor("_Color", cor);
            tilemapRenderer.material.SetFloat("_Intensity", intensidadeCorConstrasteTilemap);
        }
    }

    public void mudaMaterial(GameObject objeto){ // dependendo do tipo do objeto, pega SpriteRenderer ou TileMapRenderer
        if (objeto.CompareTag("ParedeChao")) {
            tilemapRenderer = objeto.GetComponent<TilemapRenderer>();
            spriteRenderer = null;
            tilemapRenderer.material = materialAltoContraste;
        } else {
            this.spriteRenderer = objeto.GetComponent<SpriteRenderer>();
            tilemapRenderer = null;
            spriteRenderer.material = materialAltoContraste;
        }
    }

    public void altoContrasteRecall(){
        if (PlayerPrefs.GetInt("AltoContraste") == 1) {
            foreach (string tag in tagsLista) {
                GameObject[] listaEncontrados = GameObject.FindGameObjectsWithTag(tag);
                for (int i = 0; i < listaEncontrados.Length; i++) {
                    this.altoContraste(listaEncontrados[i]);
                }
            }
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }
    }

    
    // public void altoContraste(SpriteRenderer[] objetos){
    //     foreach (SpriteRenderer objeto in objetos){
    //         mudaMaterial(objeto);
    //         Color corSelecionada;
    //         try{
    //             corSelecionada = cores[tagsLista.IndexOf(objeto.tag)];
    //         }catch{
    //             corSelecionada = Color.green;
    //         }
    //         mudarCorIntensidade(corSelecionada);
    //     }
    // }
    // public void altoContraste(TilemapRenderer[] objetos){
    //     foreach (TilemapRenderer objeto in objetos){
    //         mudaMaterial(objeto);
    //         Color corSelecionada;
    //         try{
    //             corSelecionada = cores[tagsLista.IndexOf(objeto.tag)];
    //         }catch{
    //             corSelecionada = Color.green;
    //         }
    //         Debug.Log("Objeto: " + objeto.tag + " Cor: " + corSelecionada.ToString());
    //         mudarCorIntensidade(corSelecionada);
    //     }
    // }
    // public void mudaMaterial(SpriteRenderer objeto){ // dependendo do tipo do objeto, pega SpriteRenderer ou TileMapRenderer
    //     this.spriteRenderer = objeto.GetComponent<SpriteRenderer>();
    //     this.tilemapRenderer = null;
    //     this.spriteRenderer.material = materialAltoContraste;
        
    // }
    // public void mudaMaterial(TilemapRenderer objeto){ // dependendo do tipo do objeto, pega SpriteRenderer ou TileMapRenderer
    //     this.tilemapRenderer = objeto.GetComponent<TilemapRenderer>();
    //     this.spriteRenderer = null;
    //     this.tilemapRenderer.material = materialAltoContraste;
        
    // }
}
