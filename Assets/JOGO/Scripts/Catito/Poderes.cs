using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Poderes : MonoBehaviour
{
    // Start is called before the first frame update
    private bool imortal{ get; set;}
    private const float tempoImortalidade = 4;
    private ComportamentoAmeaca ameacaAtivador;
    private Animator catitoAnim;
    [SerializeField] private Image imortalIcon;
    private Pontuador pontuador;

    void Start(){
        pontuador = FindFirstObjectByType<Pontuador>();
        imortal = false;
        imortalIcon.enabled = false;
        this.catitoAnim = this.GetComponent<Animator>();
    }
    public IEnumerator Imortalidade(){
        imortal = true;
        imortalIcon.enabled = true;
        catitoAnim.SetBool("Imortal", true);
        print("ta imortal legal");

        yield return new WaitForSeconds(tempoImortalidade);

        print("ta morrivel legal");
        imortal = false;
        imortalIcon.enabled = false;
        catitoAnim.SetBool("Imortal", false);
    }

    public void DoublePoints(){
        StartCoroutine(Pontuador.instance.duplicaValores());
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
