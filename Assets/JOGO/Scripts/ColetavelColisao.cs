using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelColisao : MonoBehaviour
{
    private Pontuador pontuador;
    private Poderes poderes;
    private Animator coletavelAnimator;

    void Start(){
        this.pontuador = FindObjectOfType<Pontuador>();
        this.coletavelAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Catito")){
            switch(this.gameObject.tag){
            	case ("Moeda"):
                    pontuador.pontuaMoeda();
                    
                    StartCoroutine(Sumir());
            	break;		

                case ("EspecialImortal"):
                    poderes = collider.gameObject.GetComponent<Poderes>();
                    StartCoroutine(poderes.Imortalidade());
                    Destroy(this.gameObject);//Colocar animação correta
                break;
            }
    	}
    }

    private IEnumerator Sumir() {
        coletavelAnimator.SetTrigger("Coletado");
        yield return new WaitForSeconds(0.5f);
        Object.Destroy(this.gameObject);
        
    }

    
}
