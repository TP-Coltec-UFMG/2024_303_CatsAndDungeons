using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatitoColisao : MonoBehaviour
{
    private Pontuador pontuador;
    private GeradorPlataforma gerador;
    private new CameraTreme camera;
    [SerializeField] private CameraSegue cameraSegue;
    private Rigidbody2D rbCatito;
    private Display orientacao;
    private Animator catitoAnim;
    [SerializeField] float forcaImpulso;
    [SerializeField] float tempoRecuo;
    private float velocidadeCatito;
    public Vector2 posicaoInicial;
    private float timer;
    private const int tempoMonstro = 8;
    private Poderes poderes;
    private bool podeTomarDano;
    private bool podeMorrer;
    private CatitoCorrida catitoCorrida;
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
        catitoCorrida = this.GetComponent<CatitoCorrida>();
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
        
        podeMorrer = (timer < tempoMonstro) && (timer > 2);
        podeTomarDano = timer > 2;

        if(!podeTomarDano){
            catitoAnim.SetBool("AtordoadoImortal", true);
        }else{
            catitoAnim.SetBool("AtordoadoImortal", false);
        } 
    }

    void OnTriggerEnter2D(Collider2D colider){
        switch (colider.tag){
            case "Gerador":
                StartCoroutine(gerador.criaPlataforma());
                colider.enabled = false;
                break;
            
            case "Transferidor":
                gerador.MudaCena();
                Destroy(colider.gameObject);
                break;
                
            case "MudaCamMov":
                cameraSegue.podeMover = !cameraSegue.podeMover;
                if(CinematicoBrain.instance!=null){
                    if(cameraSegue.podeMover){
                        CinematicoBrain.instance.DesligarCinematica();
                    }else{
                        CinematicoBrain.instance.LigarCinematica();
                    }
                }else{
                    print("Cinematico nao encontrado");
                }
                
                Destroy(colider.gameObject);
                break;
        }
    }

    public void simplifiedReceberDano(){
        StartCoroutine(RecebeDano());
    }

    IEnumerator RecebeDano(){
        
        if (!poderes.isImortal()){
            if (podeMorrer){
                GerenciadorAudio.instance.TocarSFX("Morte");
                menu.GameOver();
            }
            else if (podeTomarDano){
                
                if(GerenciadorAudio.instance!=null){
                	GerenciadorAudio.instance.TocarSFX("Tomar Dano");
                }
                catitoAnim.SetTrigger("Knockback");
                catitoAnim.SetBool("AtordoadoImortal", false);
                timer = 0;
                camera.Shake(tempoMonstro, 1f, 1f);

                if (this.orientacao == Display.horizontal){
                    rbCatito.AddForce(new Vector2(-forcaImpulso, 0), ForceMode2D.Impulse);
                    yield return new WaitForSeconds(tempoRecuo);
                    catitoCorrida.AjustaCatitoDirecao();

                }
                else if (this.orientacao == Display.vertical){

                    if (rbCatito.velocity.y > 0) { //indo pra cima
                        rbCatito.AddForce(new Vector2(0, -forcaImpulso), ForceMode2D.Impulse);
                        yield return new WaitForSeconds(tempoRecuo);
                        catitoCorrida.AjustaCatitoDirecao();
                    }

                    else if (rbCatito.velocity.y < 0) {//indo pra baixo    
                        rbCatito.AddForce(new Vector2(0, forcaImpulso), ForceMode2D.Impulse);
                        yield return new WaitForSeconds(tempoRecuo);
                        catitoCorrida.AjustaCatitoDirecao();
                    }
                }
            }
        }
    }

    //Faz com que o catito tenha alguns segundos de invencibilidade após atacar
    public void AtaqueIframes(){
        if(timer>2){
            timer = 1.6f;
        }
    }
    public bool estaAtordoado(){
        if (timer<tempoMonstro){
            return true;
        } else{
            return false;
        }
    }
}
