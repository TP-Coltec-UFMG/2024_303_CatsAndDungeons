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
    public void MataAmeaca(){
        //coisa q acontece quando o obstaculo ou inimigo morre
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Catito")){
            this.catitoColisao = collider.gameObject.GetComponent<CatitoColisao>();
            this.catitoPoderes = collider.gameObject.GetComponent<Poderes>();
            if(catitoPoderes.isImortal()){
                if (this.CompareTag("Inimigo")){
                    inimigoMorte.Morrer();
                } else {
                    ameacaAnimator.SetTrigger("Morrer");
                }
            }else{
                this.catitoColisao.simplifiedReceberDano();
            }
            
            
        }
    }


}
