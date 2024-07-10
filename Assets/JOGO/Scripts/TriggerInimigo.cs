using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInimigo : MonoBehaviour
{


    private CatitoColisao catitoColisao;
    private Animator inimigoAnim;
    private bool atacando;
    private Collider2D colliderTrigger;

    private InimigoMorte inimigoMorte;

    private bool tocandoCatito;
    // Start is called before the first frame update
    void Start()
    {
        inimigoAnim = transform.parent.GetChild(0).gameObject.GetComponent<Animator>();
        inimigoMorte = this.transform.parent.GetChild(0).gameObject.GetComponent<InimigoMorte>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacando && tocandoCatito && !inimigoMorte.morto)
        {
            catitoColisao.simplifiedReceberDano();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Catito")){
            tocandoCatito = true;
            catitoColisao = collider.gameObject.GetComponent<CatitoColisao>();
            switch (this.gameObject.name)
            {
                case "TriggerEsquerda":
                    inimigoAnim.SetTrigger("Esquerda");
                    break;

                case "TriggerDireita":
                    inimigoAnim.SetTrigger("Direita");
                    break;

                case "TriggerCima":
                    inimigoAnim.SetTrigger("Cima");
                    break;

                case "TriggerBaixo":
                    inimigoAnim.SetTrigger("Baixo");
                    break;
            }
            StartCoroutine(extensaoAtaque());
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Catito"))
        {
            tocandoCatito = false;
        }
    }

    private IEnumerator extensaoAtaque(){
        if (this.inimigoMorte.morto == false)
        {
            yield break;
        }
        yield return new WaitForSeconds(0.2f);

        if (this.inimigoMorte.morto == false)
        {
            yield break;
        }
        atacando = true; //ativa o collider de ataque
        yield return new WaitForSeconds(0.2f);

        if (this.inimigoMorte.morto == false)
        {
            yield break;
        }
        atacando = false;
        //colisorAtaque.SetActive(atacando); //desativa o collider de ataque
    }
}
