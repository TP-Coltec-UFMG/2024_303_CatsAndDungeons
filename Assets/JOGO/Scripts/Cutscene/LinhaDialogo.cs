using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace Dialogo {
    public class LinhaDialogo : ClasseBaseDialogo {
        
        private TMP_Text caixaTexto;
        
        [Header ("Texto")]  
        [SerializeField] string texto = "Oiii!!!";
        [SerializeField] Color corDoTexto = Color.white;
        [SerializeField] TMP_FontAsset fonte;
        [SerializeField] float tamanhoFonte = 24.5f;
        
        [Header ("Demais definições")]  
        [SerializeField] float delayEntreLetras = 0.05f; 
        [SerializeField] AudioClip audioLetra;

        void Awake()
        {
            caixaTexto = this.GetComponentInParent<TMP_Text>();
            caixaTexto.text = "";
        }

        void Start()
        {
            StartCoroutine(EscreverTexto(this.texto, this.caixaTexto, this.corDoTexto, this.fonte, this.tamanhoFonte, this.delayEntreLetras, this.audioLetra));
        }
    }
}

