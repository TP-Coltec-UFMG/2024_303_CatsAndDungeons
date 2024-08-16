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
    public int pontuacaoTotal, pontuacaoExterna;
    [SerializeField] private TMP_Text textoPontuacaoPainel;
    //Pontuação moedas
    [SerializeField] private TMP_Text textoMoedas;
    private int valorMoeda = 3;
    private int num = 1;
    public int pontuacaoMoedas;
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

    }

    // Update is called once per frame
    void Update() { 
        timer += Time.deltaTime*num;
        pontuacaoTotal = (int)Math.Ceiling(timer) + pontuacaoExterna;
        textoPontuacao.text = pontuacaoTotal.ToString();
    }

    public void pontuaMoeda(){
        pontuacaoMoedas++;
        textoMoedas.text = pontuacaoMoedas.ToString();
        pontuacaoExterna += valorMoeda;
    }


    public void zeraPontuacao(){
        timer = 0;
        pontuacaoMoedas = 0;
        pontuacaoExterna = 0;
        pontuacaoTotal = 0;
        textoMoedas.text = pontuacaoMoedas.ToString();
        textoPontuacao.text = pontuacaoTotal.ToString();
    }

    public IEnumerator duplicaValores() {
        valorMoeda = valorMoeda*2;
        num = 2;
        doublePointsIcon.enabled = true;
        pontosAnimator.SetBool("Dobrado", true);
        yield return new WaitForSeconds(10);

        
        valorMoeda = valorMoeda/2;
        num = 1;
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
        
        if(SceneLoader.IsGameScene()){
            doublePointsIcon = GameObject.Find("DoublePointsIcon").GetComponent<Image>();
        }else{
            Destroy(this.gameObject);
        }
    }
}
