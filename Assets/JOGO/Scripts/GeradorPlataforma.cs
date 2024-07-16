using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeradorPlataforma : MonoBehaviour
{
    private List<Plataforma> plataformas = new List<Plataforma>();
    [SerializeField] private List<GameObject> gameObPlats = new List<GameObject>();
    private List<GameObject> Areas = new List<GameObject>();
    int plataformasusadas = 0;
    int indicePlatSelecionada;
    int ultimoindice = -1;
    int tamanho;
    private string cenaAtual;
    [SerializeField] GameObject plataformaInicial;
    GameObject plataformaSpawnada;
    private MudarContraste mudarContraste;
    private quantidadePlataformas = 0;
    

    // Start is called before the first frame update
    void Start() {
        mudarContraste = this.GetComponent<MudarContraste>();

        //PEGA O TAMANHO DA PRIMEIRA PLATAFORMA A SER COLOCADA
        plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        if(cenaAtual == "CenaAcessivel"){
            tamanho = plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.y;
        } else {
            tamanho = plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x - 5;
        }

        //COLOCA OS TEMPLATES DE PLATAFORMAS NA LISTA
        for (int i = 0; i < gameObPlats.Count; i++){
            plataformas.Add(new Plataforma(gameObPlats[i]));
        }
    }

    public void criaPlataforma(){

        do {
            indicePlatSelecionada = (int)UnityEngine.Random.Range(0, plataformas.Count);
        } while(plataformas[indicePlatSelecionada].foiSpawnada || indicePlatSelecionada == ultimoindice);
        
        int PlataformaTamanho;
        if(cenaAtual == "CenaAcessivel"){
            plataformaSpawnada = Instantiate(plataformas[indicePlatSelecionada].objetoPlataforma, new Vector3(0, tamanho), Quaternion.identity);//x, y
            plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            PlataformaTamanho = plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.y;
        } else{
            plataformaSpawnada = Instantiate(plataformas[indicePlatSelecionada].objetoPlataforma, new Vector3(tamanho, 0), Quaternion.identity);//x, y
            plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            PlataformaTamanho = plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        }
        tamanho += PlataformaTamanho;

        plataformas[indicePlatSelecionada].foiSpawnada = true;
        ultimoindice = indicePlatSelecionada;

        plataformasusadas++;
        quantidadePlataformas++;

        if (quantidadePlataformas == 10) {
            quantidadePlataformas = 0;
            
        }

        if (plataformasusadas == plataformas.Count) {
            for(int i = 0; i < plataformas.Count; i++){
                plataformas[i].foiSpawnada = false;
            }
            plataformasusadas = 0;
        }

        ativaItens();

        //APLICAR ALTO CONTRASTE
        //mudarContraste.altoContraste(plataformaSpawnada.GetComponentsInChildren<SpriteRenderer>());
        //mudarContraste.altoContraste(plataformaSpawnada.GetComponentsInChildren<TilemapRenderer>());
        mudarContraste.altoContrasteRecall();
    }

    void ativaItens(){
        //Horizontal

        //Pega os containers com os esquemas
        Transform caixaDeEsquemasH = plataformaSpawnada.transform.GetChild(2).GetChild(0).transform;
        Transform caixaDeEsquemasV = plataformaSpawnada.transform.GetChild(2).GetChild(1).transform;
        //Pega os containers com as areas
        Transform containerAreasH = plataformaSpawnada.transform.GetChild(1).GetChild(0).transform;
        Transform containerAreasV = plataformaSpawnada.transform.GetChild(1).GetChild(1).transform;

        //COLETA QUANTIDADE DE ESQUEMAS DE CADA TIPO
        int quantEsquemasH = caixaDeEsquemasH.childCount; //Coleta a quantidade de esquemasH e coloca na vari�vel quantEsquemasH
        int quantEsquemasV = caixaDeEsquemasV.childCount; //Coleta a quantidade de esquemasV e coloca na vari�vel quantEsquemasV

        //COLETA QUANTIDADE DE AREAS DE CADA TIPO
        int quantAreasH = containerAreasH.childCount;//coleta a quantidade de �reasH
        int quantAreasV = containerAreasV.childCount;//coleta a quantidade de �reasV

        //ORGANIZAR ESQUEMAS 
        GameObject[] esquemasH = new GameObject[quantEsquemasH]; //cria um vetor vazio com o tamanho sendo a quantidade de esquemas
        GameObject[] esquemasV = new GameObject[quantEsquemasV]; //cria um vetor vazio com o tamanho sendo a quantidade de esquemas
        
        for (int i = 0; i< quantEsquemasH; i++){
            esquemasH[i] = caixaDeEsquemasH.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
        }
        for (int i = 0; i < quantEsquemasV; i++) {
            esquemasV[i] = caixaDeEsquemasV.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
        }

        //ORGANIZAR AREAS
        GameObject[] areasH = new GameObject[quantAreasH];
        GameObject[] areasV = new GameObject[quantAreasV];
        for (int i = 0; i < quantAreasH; i++) {
            areasH[i] = containerAreasH.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
        }
        for (int i = 0; i < quantAreasV; i++) {
            areasV[i] = containerAreasV.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
        }


        //COLOCAR ESQUEMAS EM CADA �REA

        //HORIZONTAL
        for (int i = 0; i < quantAreasH; i++) {
            GameObject area = areasH[i];
            
            int indiceEsquema;

           
            do{ 
                indiceEsquema = (int)UnityEngine.Random.Range(0, quantEsquemasH); //Sorteia um esquema para colocar at� pegar um que j� n�o tenha sido ativado
            } while(esquemasH[indiceEsquema].activeInHierarchy);

            print("indice spawnado" + indiceEsquema);
            esquemasH[indiceEsquema].transform.position = area.transform.position;
            esquemasH[indiceEsquema].SetActive(true);
        }

        //VERTICAL
        for (int i = 0; i < quantAreasV; i++) {
            GameObject area = areasV[i];

            int indiceEsquema;

            
            do {
                indiceEsquema = (int)UnityEngine.Random.Range(0, quantEsquemasV); //Sorteia um esquema para colocar at� pegar um que j� n�o tenha sido ativado
            } while (esquemasV[indiceEsquema].activeInHierarchy);

            print("indice spawnado" + indiceEsquema);
            esquemasV[indiceEsquema].transform.position = area.transform.position;
            esquemasV[indiceEsquema].SetActive(true);
        }

    }

}