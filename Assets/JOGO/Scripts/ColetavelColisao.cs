using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelColisao : MonoBehaviour
{
    private Pontuador pontuador;
    private Poderes poderes;
    private Animator coletavelAnimator;
    private bool coletado = false;

    void Start(){
        this.pontuador = FindObjectOfType<Pontuador>();
        this.coletavelAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Catito")){
            if(!coletado){
                switch(this.gameObject.tag){
                    case ("Moeda"):
                        //GerenciadorAudio.instance.TocarSFX("");
                        pontuador.pontuaMoeda();
                        GerenciadorAudio.instance.TocarSFX("Pegar Moeda");

                        StartCoroutine(Sumir());
                    break;		

                    case ("EspecialImortal"):
                        poderes = collider.gameObject.GetComponent<Poderes>();
                        GerenciadorAudio.instance.TocarSFX("PowerUp Imortal");
                        StartCoroutine(poderes.Imortalidade());
                        StartCoroutine(Sumir());
                    break;

                    case ("EspecialPontos"):
                        GerenciadorAudio.instance.TocarSFX("PowerUp DoublePoints");
                        poderes = collider.gameObject.GetComponent<Poderes>();
                        poderes.DoublePoints();
                        Object.Destroy(this.gameObject);
                    break;
                }
            }
    	}
    }

    private IEnumerator Sumir() {
        coletavelAnimator.SetTrigger("Coletado");
        yield return new WaitForSeconds(3);
        Object.Destroy(this.gameObject);
        
    }

    
}
