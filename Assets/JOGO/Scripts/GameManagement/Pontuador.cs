using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Pontuador : MonoBehaviour
{
    //Distância
    public float timer;
    [SerializeField] private TMP_Text textoDistanciaPainel;

    //Pontuação total
    [SerializeField] private TMP_Text textoPontuacao;
    private TMP_Text textoPontuacaoRecorde;
    public int pontuacaoTotal, pontuacaoExterna;
    [SerializeField] private TMP_Text textoPontuacaoPainel;
    //Pontuação moedas
    [SerializeField] private TMP_Text textoMoedas;
    private const int valorMoedaPadrao = 3;
    private int valorMoeda = 3;
    private const float ganhoPontosFacil = 2;
    private const float ganhoPontosMedio = 3;
    private const float ganhoPontosDificil = 4;
    private float ganhoPontosPadrao;
    private float ganhoPontos;
    public int pontuacaoMoedas;
    private int valorAmeaca = 10;
    private int multiplicador = 1;
    [SerializeField] private TMP_Text textoMoedasPainel;
    private Image doublePointsIcon;
    [SerializeField] private Animator pontosAnimator;

    
    public static Pontuador instance { get; private set; }
    //Para usar o Gerenciador de �udio, use Pontuador.instance.Funcao(); ou Pontuador.instance.atributo;
    
    
    
    void Awake() //
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        
    }
    
    
    // Start is called before the first frame update
    void Start(){
        pontuacaoMoedas = 0;
        textoMoedas.text = pontuacaoMoedas.ToString();
        doublePointsIcon = GameObject.Find("DoublePointsIcon").GetComponent<Image>();
        doublePointsIcon.enabled = false;
        textoPontuacaoRecorde = this.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        textoPontuacaoRecorde.text = PlayerPrefs.GetInt("RecordePontos").ToString();
    }

    // Update is called once per frame
    void Update() { 
        if(StatusJogo.statusAtual == Status.gameplay){
            //Debug.Log("toma ponto" + Time.deltaTime + " " + ganhoPontos + " " + multiplicador);
            timer += Time.deltaTime*ganhoPontos*multiplicador;
        }
        
        
        pontuacaoTotal = (int)Math.Ceiling(timer) + pontuacaoExterna;
        if(pontuacaoTotal > PlayerPrefs.GetInt("RecordePontos")){
            PlayerPrefs.SetInt("RecordePontos", pontuacaoTotal);
            textoPontuacaoRecorde.text = pontuacaoTotal.ToString();
        }
        textoPontuacao.text = pontuacaoTotal.ToString();
    }
    public void SetPontuacaoInicial(){
        switch(PlayerPrefs.GetInt("Dificuldade")){
                case 0:
                    ganhoPontosPadrao = ganhoPontosFacil;
                    break;
                case 1:
                    ganhoPontosPadrao = ganhoPontosMedio;
                    break;
                case 2:
                    ganhoPontosPadrao = ganhoPontosDificil;
                      break;
                default:
                    Debug.LogError("Erro na disposicao da dificuldade, assimilando valor padrao de ganho de pontos");
                    ganhoPontosPadrao = ganhoPontosMedio;
                    break;
        }  
        ganhoPontos = ganhoPontosPadrao;
    }
    public void pontuaMoeda(){
        pontuacaoMoedas++;
        textoMoedas.text = pontuacaoMoedas.ToString();
        pontuacaoExterna += valorMoeda * multiplicador;
    }
    public void PontuaDestruirAmeaca(){
        pontuacaoExterna += valorAmeaca * multiplicador;
    }

    public void ZeraPontuacao(){
        timer = 0;
        pontuacaoMoedas = 0;
        pontuacaoExterna = 0;
        pontuacaoTotal = 0;
        textoMoedas.text = pontuacaoMoedas.ToString();
        textoPontuacao.text = pontuacaoTotal.ToString();
    }

    public void DuplicaValores(){
        StartCoroutine(DuplicaValoresCoroutine());
    }
    public IEnumerator DuplicaValoresCoroutine() {
        
        //valorMoeda = valorMoedaPadrao*2;
        //ganhoPontos = ganhoPontosPadrao*2;
        multiplicador = 2;
        doublePointsIcon.enabled = true;
        pontosAnimator.SetBool("Dobrado", true);

        yield return new WaitForSeconds(10f);

        multiplicador = 1;
        //valorMoeda = valorMoedaPadrao;
        //ganhoPontos = ganhoPontosPadrao;
        
        doublePointsIcon.enabled = false;
        pontosAnimator.SetBool("Dobrado", false);

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
        Debug.Log("Cena trocada para: " + scene.name);
        Debug.Log("A dificuldade atual: " + PlayerPrefs.GetInt("Dificuldade"));
        //Facil = 0  Medio = 1  Dificil = 2

        if(SceneLoader.IsGameScene()){
            doublePointsIcon = GameObject.Find("DoublePointsIcon").GetComponent<Image>();
        }else{
            Destroy(this.gameObject);
        }
    }
}
