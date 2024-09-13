using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorte : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator inimigoAnim;
    private Transform inimigoPai;
    private Collider2D inimigoCollider;
    public bool morto {get; private set;} = false;
    private const float forcaEmpurrao = 2f;
    private void Start()
    {
        inimigoPai = this.transform.parent;
        inimigoCollider = this.GetComponent<Collider2D>();
        inimigoAnim = this.GetComponent<Animator>();
    }
    public void Morrer() {

        this.morto = true;
        inimigoCollider.enabled = false;
        Transform catitoTransform = GameObject.FindWithTag("Catito").transform;
        Rigidbody2D inimigoRb = this.GetComponent<Rigidbody2D>();

        Pontuador.instance.PontuaDestruirAmeaca();
        Vector3 direcaoEmpurrao = (transform.position - catitoTransform.position).normalized;

            // Aplica a força na direção oposta ao jogador
        inimigoRb.AddForce(direcaoEmpurrao * forcaEmpurrao, ForceMode2D.Impulse);
        
        this.SortearSomMorte();
        inimigoAnim.SetTrigger("Morrer");

        StartCoroutine(MorteTime());
    }

    private IEnumerator MorteTime(){
        yield return new WaitForSeconds(1);
        for (int i = 1; i < inimigoPai.childCount; i++) { //pra cada filho do pai do inimigo, excluindo o proprio inimigo, desative o gameobject
            this.inimigoPai.GetChild(i).gameObject.SetActive(false);
        }
        Destroy(this.inimigoPai.gameObject);
    }

    private void SortearSomMorte(){
        switch(Random.Range(0, 3)){//retorna um inteiro entre 0 e 1
            case 0:
                GerenciadorAudio.instance.TocarSFX("InimigoMorte");
                break;
            case 1:
                GerenciadorAudio.instance.TocarSFX("InimigoMorteB");
                break;
            case 2:
                GerenciadorAudio.instance.TocarSFX("InimigoMorteC");
                break;
            default:
                print("Sortearam o som meio errado aqui");
                break;
        }
    }
}