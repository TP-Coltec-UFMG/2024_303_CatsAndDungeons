using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComecarJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name.Contains("PrincipalInicial")){
            //coisa q acontece se for cena inicial
            
            StartCoroutine(estadoInicialJogo());
        }
    }

    private IEnumerator estadoInicialJogo(){

        Animator PressAnyKeyAnim = GameObject.Find("PressAnyKeyCanvas").GetComponent<Animator>();
        CatitoCorrida catitoCorrida = GameObject.Find("Catito").GetComponent<CatitoCorrida>();
        GameObject pontuador = GameObject.Find("Pontuador");
        Animator pontuadorAnim = GameObject.Find("Pontuador").GetComponent<Animator>();

        Animator UIAnim = GameObject.Find("--UI--").transform.GetChild(0).GetComponent<Animator>();

        StatusJogo.statusAtual = Status.cinema;

        
        //desliga as coisas tipo deixar o gato em idle
        
        while (true) {
            if (Input.anyKeyDown){
                //Faca tal coisa
                //liga as coisa 
                pontuadorAnim.SetTrigger("Surgir");
                UIAnim.SetTrigger("Surgir");
                break;
            }
            yield return null;
        }
        //yield return new WaitUntil(() => Input.anyKeyDown);
    }

    
}
