using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iniciaJogo : MonoBehaviour
{
    [SerializeField] private Animator botaoAnim, gatoAnim, menuAtrasAnim;

    private Button[] botoes;

    void Start(){
        botoes = botaoAnim.gameObject.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update(){

        //vai ser ativado quando qualquer botao for pressionado, isso inclui o click do mouse
        if (Input.anyKeyDown){

            //avisa pros animator do gato e dos botoes que eles ja podem aparecer

            menuAtrasAnim.SetBool("iniciado", true);

            StartCoroutine(ligarBotoes());//neg�cio q faz funcionar fun��es que usem waitForSeconds
        }
    }

    //IEnumerator pq � o tipo do wait for seconds sla n sei ciencia da computa��o sei de nada
    IEnumerator ligarBotoes(){
        yield return new WaitForSeconds(1); //espera 2 segundos antes de fazer as outras intru��es do c�digo

        //deixa os botoes interativos         (sim eu deixei pra eles ficarem n�o interativos quando inicia o jogo)
        for (int i = 0; i < botoes.Length; i++){
            botaoAnim.SetBool("iniciado", true);
            gatoAnim.SetBool("iniciado", true);

            botoes[i].interactable = true; 
        }
    }
}