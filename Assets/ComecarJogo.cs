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
        //CatitoCorrida catitoCorrida = GameObject.Find("Catito").GetComponent<CatitoCorrida>();
        //GameObject pontuador = GameObject.Find("Pontuador");
        Animator pontuadorAnim = GameObject.Find("Pontuador").GetComponent<Animator>();

        Animator UIAnim = GameObject.Find("--UI--").transform.GetChild(0).GetComponent<Animator>();

        StatusJogo.statusAtual = Status.inicial;

        
        
        while (true) {
            if (Input.anyKeyDown){
                //Faca tal coisa
                //liga as coisa 
                StatusJogo.statusAtual = Status.gameplay;
                PressAnyKeyAnim.SetTrigger("Sumir");
                pontuadorAnim.SetTrigger("Surgir");
                UIAnim.SetTrigger("Surgir");
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        PressAnyKeyAnim.gameObject.SetActive(false);
        //yield return new WaitUntil(() => Input.anyKeyDown);
    }

    
}
