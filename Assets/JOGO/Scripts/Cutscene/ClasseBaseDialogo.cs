using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Accessibility;

namespace Dialogo
{
    public class ClasseBaseDialogo : MonoBehaviour{
        public bool DialogoConcluido {get; private set;}
        private bool Adiantado = true;
        private bool leitorTela = false;
        GameObject pressAnyKey;
        
        //protected pois quero que apenas que quem herde essa classe possa usar a funcao
        protected IEnumerator EscreverTexto(string texto, TMP_Text caixaTexto, Color corTexto, TMP_FontAsset fonte, float tamanhoFonte, float delayEntreLetras, AudioClip audioLetra){
            
            caixaTexto.font = fonte;
            caixaTexto.color = corTexto;
            caixaTexto.fontSize = tamanhoFonte;
            if(UAP_AccessibilityManager.IsEnabled()){
                
                leitorTela = true;
            }else{
                
                leitorTela = false;
            }
            
            yield return new WaitForSeconds(0.1f);
            foreach(Transform child in transform){
                if(child.gameObject.CompareTag("PressAnyKey")){
                    pressAnyKey = child.gameObject;
                    break;
                }               
            }
            
            //Checa se leitor de tela tá ligado para ver se faz som ou nao

            //adiciona cada letra de cada vez
            yield return new WaitForSeconds(0.1f);
            Adiantado = false;

            //Digita cada letra do dialogo
            for(int i = 0;i<texto.Length;i++){
                caixaTexto.text += texto[i];
                if (!leitorTela && texto[i]!=' '){
                    
                    GerenciadorAudio.instance.TocarSFX(audioLetra);
                }else{
                    
                }

                yield return new WaitForSeconds(delayEntreLetras);
                if (Adiantado){
                    caixaTexto.text = texto;
                    break;
                }
            }
            Adiantado = false;
            yield return new WaitForSeconds(0.1f);

            //espera ate o jogador clicar na tela para pular o dialogo
            //fazer botão surgir
            if(pressAnyKey!=null){
                pressAnyKey.SetActive(true);
            }
            while (true) {
                if (Input.anyKeyDown){
                    DialogoConcluido = true;
                    break;
                }
                yield return null;
            }            
        }
        void Update(){
            if (Input.anyKeyDown){
                    Adiantado = true;
            }
        }
    }
}

