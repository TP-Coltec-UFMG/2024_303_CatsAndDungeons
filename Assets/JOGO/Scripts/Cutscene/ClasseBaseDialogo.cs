using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dialogo
{
    public class ClasseBaseDialogo : MonoBehaviour{
        public bool DialogoConcluido {get; private set;}

        //protected pois quero que apenas que quem herde essa classe possa usar a funcao
        protected IEnumerator EscreverTexto(string texto, TMP_Text caixaTexto, Color corTexto, TMP_FontAsset fonte, float tamanhoFonte, float delayEntreLetras, AudioClip audioLetra){
            
            caixaTexto.font = fonte;
            caixaTexto.color = corTexto;
            caixaTexto.fontSize = tamanhoFonte;

            //adiciona cada letra de cada vez
            for(int i = 0;i<texto.Length;i++){
                caixaTexto.text += texto[i];
                GerenciadorAudio.instance.TocarSFX(audioLetra);
                yield return new WaitForSeconds(delayEntreLetras);
            }

            //espera ate o jogador clicar na tela para pular o dialogo
            yield return new WaitUntil(() =>Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space));
            DialogoConcluido = true;
        }
    }
}

