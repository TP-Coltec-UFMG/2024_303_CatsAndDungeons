using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoAmeaca : MonoBehaviour
{
    // Start is called before the first frame update

    private CatitoColisao catitoColisao;
    private Poderes catitoPoderes;
    private Animator ameacaAnimator;
    private InimigoMorte inimigoMorte;

    void Start(){
        this.ameacaAnimator = this.GetComponent<Animator>();
        this.inimigoMorte = this.GetComponent<InimigoMorte>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Catito")){
            this.catitoColisao = collider.gameObject.GetComponent<CatitoColisao>();
            this.catitoPoderes = collider.gameObject.GetComponent<Poderes>();
            if(this.catitoPoderes.isImortal()){

                if (this.CompareTag("Inimigo")){
                    this.inimigoMorte.Morrer();
                } else {
                    this.DestruirArmadilha();
                }

            }else{
                this.catitoColisao.simplifiedReceberDano();
            }
            
            
        }
    }
    
    private void DestruirArmadilha(){
        this.GetComponent<Collider2D>().enabled = false;
        GerenciadorAudio.instance.TocarSFX("Explodir Armadilha");
        this.ameacaAnimator.SetTrigger("Morrer");
        Pontuador.instance.PontuaDestruirAmeaca();
    }

}
