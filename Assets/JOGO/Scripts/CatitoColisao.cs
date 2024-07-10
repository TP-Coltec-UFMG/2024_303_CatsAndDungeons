using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatitoColisao : MonoBehaviour
{
    private Pontuador pontuador;
    private GeradorPlataforma gerador;
    private new CameraTreme camera;

    private Rigidbody2D rbCatito;
    private Display orientacao;
    private Animator catitoAnim;
    [SerializeField] private GameObject painel;
    [SerializeField] float forcaImpulso;
    private float velocidadeCatito;
    public Vector2 posicaoInicial;
    private float timer;
    private const int tempoMonstro = 8;
    private Poderes poderes;
    private bool podeTomarDano;
    private bool podeMorrer;

    private Menus menu;

    void Start(){
        this.pontuador = FindObjectOfType<Pontuador>();
        this.gerador = FindObjectOfType<GeradorPlataforma>();
        this.camera = FindObjectOfType<CameraTreme>();
        this.poderes = this.GetComponent<Poderes>();
        this.menu = FindObjectOfType<Menus>();
        this.rbCatito = this.gameObject.GetComponent<Rigidbody2D>();
        timer = tempoMonstro;
        catitoAnim = this.GetComponent<Animator>();
    }

    // Awake is called everytime the scene starts
    void Awake(){
        this.posicaoInicial = this.transform.position;
    }

    // Update is called once per frame
    void Update(){
        this.orientacao = this.gameObject.GetComponent<CatitoCorrida>().orientacao;
        this.velocidadeCatito = this.gameObject.GetComponent<CatitoCorrida>().velocidadeCatito;
        timer += Time.deltaTime;
        
        podeMorrer = ((timer < tempoMonstro) && (timer > 2));
        podeTomarDano = timer > 2;

        if(!podeTomarDano){
            catitoAnim.SetBool("AtordoadoImortal", true);
        }else{
            catitoAnim.SetBool("AtordoadoImortal", false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D colider){
        switch (colider.tag){
            
            case ("EspecialImortal"):
                StartCoroutine(poderes.Imortalidade());
                Destroy(colider.gameObject);
                break;

            case ("EspecialPontos"):
                StartCoroutine(pontuador.duplicaValores());
                Destroy(colider.gameObject);
                break;

            case ("Gerador"):
                gerador.criaPlataforma();
                break;
        }
    }

    public void simplifiedReceberDano(){
        StartCoroutine(recebeDano());
    }

    IEnumerator recebeDano(){
        print(podeTomarDano);
        if (!poderes.isImortal()){
            if (podeMorrer){
                GerenciadorAudio.instance.TocarSFX("Morte");
                menu.GameOver();
            }
            else if (podeTomarDano){

                if(GerenciadorAudio.instance!=null){
                	GerenciadorAudio.instance.TocarSFX("Tomar Dano");
                }
                catitoAnim.SetBool("AtordoadoImortal", false);
                timer = 0;
                camera.Shake(tempoMonstro, 1f, 1f);

                if (this.orientacao == Display.horizontal){
                    rbCatito.AddForce(new Vector2(-forcaImpulso, 0), ForceMode2D.Impulse);
                    yield return new WaitForSeconds(0.5f);

                    //rbCatito.velocity = new Vector2(velocidadeCatito * Time.deltaTime, 0);
                    rbCatito.velocity = new Vector2(velocidadeCatito, 0);

                }
                else if (this.orientacao == Display.vertical){

                    if (rbCatito.velocity.y > 0) { //indo pra cima
                        rbCatito.AddForce(new Vector2(0, -forcaImpulso), ForceMode2D.Impulse);
                        yield return new WaitForSeconds(0.5f);
                        rbCatito.velocity = new Vector2(0, velocidadeCatito);
                        //rbCatito.velocity = new Vector2(0, velocidadeCatito * Time.deltaTime);
                    }

                    else if (rbCatito.velocity.y < 0) {//indo pra baixo    
                        rbCatito.AddForce(new Vector2(0, forcaImpulso), ForceMode2D.Impulse);
                        yield return new WaitForSeconds(0.5f);

                        //rbCatito.velocity = new Vector2(0, -velocidadeCatito * Time.deltaTime);
                        rbCatito.velocity = new Vector2(0, -velocidadeCatito);
                    }
                }
                
            }
        }
        

            //Empurra Catito para trás e ativa monstro
        
    }

    public bool estaAtordoado(){
        if (timer<tempoMonstro){
            return true;
        } else{
            return false;
        }
    }

}
