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
    private int plataformasusadas = 0;
    private int indicePlatSelecionada;
    private int ultimoindice = -1;
    private int tamanho;
    private string cenaAtual;
    [SerializeField] GameObject plataformaInicial;
    [SerializeField] GameObject plataformaFinal;
    private GameObject plataformaSpawnada;
    private MudarContraste mudarContraste;
    private int quantidadePlataformas = 0;
    private SceneLoader loader;
    [SerializeField] private int maximoPlataformasArea = 5;
    [SerializeField] int quantidadeParaSubtrairPlatInicial = 5;

    // Start is called before the first frame update
    void Start() {
        mudarContraste = this.GetComponent<MudarContraste>();
        loader = this.GetComponent<SceneLoader>();

        //PEGA O TAMANHO DA PRIMEIRA PLATAFORMA A SER COLOCADA
        plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        if(cenaAtual == "CenaAcessivel"){
            tamanho = plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.y;
        } else {
            tamanho = plataformaInicial.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x - quantidadeParaSubtrairPlatInicial;
        }

        //COLOCA OS TEMPLATES DE PLATAFORMAS NA LISTA
        for (int i = 0; i < gameObPlats.Count; i++){
            plataformas.Add(new Plataforma(gameObPlats[i]));
        }
    }

    public IEnumerator criaPlataforma(){

        //Checa se já fez plataformas demais
        quantidadePlataformas++;
        if (quantidadePlataformas >= maximoPlataformasArea) {
            if(SceneLoader.IsAcessibleScene()){
                Instantiate(plataformaFinal, new Vector3(0, tamanho), Quaternion.identity);//x, y
            } else {  
                Instantiate(plataformaFinal, new Vector3(tamanho, 0), Quaternion.identity);//x, y
            }
            tamanho += 50;
        } else {		
            
            indicePlatSelecionada = 0;
            do{
                indicePlatSelecionada = (int)UnityEngine.Random.Range(0, plataformas.Count);
                if(plataformas.Count == 1 ){
                     break;
                 }
                yield return null;
            }while((plataformas[indicePlatSelecionada].foiSpawnada || indicePlatSelecionada == ultimoindice));
            
            int plataformaTamanho;
            if(SceneLoader.IsAcessibleScene()){
                plataformaSpawnada = Instantiate(plataformas[indicePlatSelecionada].objetoPlataforma, new Vector3(0, tamanho), Quaternion.identity);//x, y
                plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
                plataformaTamanho = plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.y;
            } else {
                plataformaSpawnada = Instantiate(plataformas[indicePlatSelecionada].objetoPlataforma, new Vector3(tamanho, 0), Quaternion.identity);//x, y
                plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
                plataformaTamanho = plataformaSpawnada.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            }
            tamanho += plataformaTamanho;

            plataformas[indicePlatSelecionada].foiSpawnada = true;
            ultimoindice = indicePlatSelecionada;

            plataformasusadas++;

            if (plataformasusadas == plataformas.Count) {
                for(int i = 0; i < plataformas.Count; i++){
                    plataformas[i].foiSpawnada = false;
                }
                plataformasusadas = 0;
            }

            StartCoroutine(AtivaItens());

            mudarContraste.altoContrasteRecall();
        }
        yield return null;
    }

    private IEnumerator AtivaItens(){
        //Horizontal

        //Pega os containers com as areas
        Transform containerAreasH = plataformaSpawnada.transform.GetChild(1).GetChild(0).transform;
        Transform containerAreasV = plataformaSpawnada.transform.GetChild(1).GetChild(1).transform;
        //Pega os containers com os esquemas
        Transform caixaDeEsquemasH = plataformaSpawnada.transform.GetChild(2).GetChild(0).transform;
        Transform caixaDeEsquemasV = plataformaSpawnada.transform.GetChild(2).GetChild(1).transform;
        

        //COLETA QUANTIDADE DE ESQUEMAS DE CADA TIPO
        int quantEsquemasH = caixaDeEsquemasH.childCount; //Coleta a quantidade de esquemasH e coloca na vari�vel quantEsquemasH
        int quantEsquemasV = caixaDeEsquemasV.childCount; //Coleta a quantidade de esquemasV e coloca na vari�vel quantEsquemasV

        //COLETA QUANTIDADE DE AREAS DE CADA TIPO
        int quantAreasH = containerAreasH.childCount;//coleta a quantidade de �reasH
        int quantAreasV = containerAreasV.childCount;//coleta a quantidade de �reasV

        
        if(quantEsquemasH>0 && quantAreasH>0){
            
            //ORGANIZAR ESQUEMAS 
            GameObject[] esquemasH = new GameObject[quantEsquemasH]; //cria um vetor vazio com o tamanho sendo a quantidade de esquemas
            for (int i = 0; i< quantEsquemasH; i++){
                
                esquemasH[i] = caixaDeEsquemasH.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
                yield return null;
            }
            //ORGANIZAR AREAS
            GameObject[] areasH = new GameObject[quantAreasH];
            for (int i = 0; i < quantAreasH; i++) {
                areasH[i] = containerAreasH.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
                yield return null;
            }

            yield return null;
            //COLOCAR ESQUEMAS EM CADA �REA
            //HORIZONTAL
            for (int i = 0; i < quantAreasH; i++) {
                yield return null;
                GameObject area = areasH[i];
                
                int indiceEsquema;
                int testagens = 0;
                do{ 
                    indiceEsquema = (int)UnityEngine.Random.Range(0, quantEsquemasH); //Sorteia um esquema para colocar at� pegar um que j� n�o tenha sido ativado
                    testagens++;
                } while(esquemasH[indiceEsquema].activeInHierarchy && testagens<15);

                
                esquemasH[indiceEsquema].transform.position = area.transform.position;
                esquemasH[indiceEsquema].SetActive(true);
            }
        }

        if(quantEsquemasV>0 && quantAreasV>0){
            //ORGANIZAR ESQUEMAS 
            GameObject[] esquemasV = new GameObject[quantEsquemasV]; //cria um vetor vazio com o tamanho sendo a quantidade de esquemas        
            for (int i = 0; i < quantEsquemasV; i++) {
                esquemasV[i] = caixaDeEsquemasV.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
            }

        
            GameObject[] areasV = new GameObject[quantAreasV];
            
            for (int i = 0; i < quantAreasV; i++) {
                areasV[i] = containerAreasV.GetChild(i).gameObject; //para cada �ndice do vetor esquemas, ele coloca um dos filhos do container de esquemas
            }
            yield return null;
            //COLOCAR ESQUEMAS EM CADA �REA
            //VERTICAL
            for (int i = 0; i < quantAreasV; i++) {
                yield return null;
                GameObject area = areasV[i];

                int indiceEsquema;
                int testagens = 0;
                do {
                    indiceEsquema = (int)UnityEngine.Random.Range(0, quantEsquemasV); //Sorteia um esquema para colocar at� pegar um que j� n�o tenha sido ativado
                    testagens++;
                } while (esquemasV[indiceEsquema].activeInHierarchy && testagens<15);

                
                esquemasV[indiceEsquema].transform.position = area.transform.position;
                esquemasV[indiceEsquema].SetActive(true);
            }
        }
    yield return null;
    }

    public void MudaCena(){
        StartCoroutine(SceneLoader.LoadScene());
    }
}
