using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class GameOverMenu : MonoBehaviour
{

	
    [SerializeField] private TMP_Text textoMoedasPainel;
    [SerializeField] private TMP_Text textoPontuacaoPainel;
    [SerializeField] private TMP_Text textoDistanciaPainel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void preenchePainel(){
        textoPontuacaoPainel.text = Pontuador.instance.pontuacaoTotal.ToString();
        textoDistanciaPainel.SetText("" + (int)Math.Ceiling(Pontuador.instance.timer));
        textoMoedasPainel.text = Pontuador.instance.pontuacaoMoedas.ToString();
    }
}
