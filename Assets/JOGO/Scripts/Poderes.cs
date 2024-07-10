using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Poderes : MonoBehaviour
{
    // Start is called before the first frame update
    private bool imortal{ get; set;}
    private const float tempoImortalidade = 8f;
    ComportamentoAmeaca ameacaAtivador;
    private Animator catitoAnim;

    void Start(){
        imortal = false;
        this.catitoAnim = this.GetComponent<Animator>();
    }
    public IEnumerator Imortalidade(){
        imortal = true;
        catitoAnim.SetBool("Imortal", true);
        yield return new WaitForSeconds(tempoImortalidade);
        
        imortal = false;
        catitoAnim.SetBool("Imortal", false);
    }

    public bool isImortal(){
        return imortal;
    }

    void OnCollisionEnter2D(Collision2D other){
        if (this.isImortal())
        {
            switch (other.gameObject.tag)
            {
                case "Armadilha":
                    other.collider.enabled = false;
                    ameacaAtivador.MataAmeaca();

                    break;
                case "Inimigo":
                    other.collider.enabled = false;
                    ameacaAtivador.MataAmeaca();
                    break;
            }
        }
        
    }
}
