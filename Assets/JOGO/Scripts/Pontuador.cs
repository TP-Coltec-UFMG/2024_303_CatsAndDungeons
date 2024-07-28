using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Pontuador : MonoBehaviour
{
    //Distância
    private float timer;
    [SerializeField] private TMP_Text textoDistanciaPainel;

    //Pontuação total
    [SerializeField] private TMP_Text textoPontuacao;
    private int pontuacaoTotal, pontuacaoExterna;
    [SerializeField] private TMP_Text textoPontuacaoPainel;
    //Pontuação moedas
    [SerializeField] private TMP_Text textoMoedas;
    private int valorMoeda = 3;
    private int num = 1;
    private int pontuacaoMoedas;
    [SerializeField] private TMP_Text textoMoedasPainel;
    [SerializeField] private Image doublePointsIcon;
    [SerializeField] private Animator pontosAnimator;
    // Start is called before the first frame update
    void Start(){
        pontuacaoMoedas = 0;
        textoMoedas.text = pontuacaoMoedas.ToString();
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

    public void preenchePainel(){
        textoPontuacaoPainel.text = pontuacaoTotal.ToString();
        textoDistanciaPainel.SetText("" + (int)Math.Ceiling(timer));
        textoMoedasPainel.text = pontuacaoMoedas.ToString();
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
}