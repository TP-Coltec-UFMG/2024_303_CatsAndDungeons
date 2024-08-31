using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public enum PosicoesH{cima = 1, meio = 0, baixo = -1}
public enum PosicoesV{esquerda = 1, meio = 0, direita = -1}
public enum Display{horizontal, vertical}

public class CatitoCorrida : MonoBehaviour
{
    public float velocidadeCatito = 6;
    public float velocidadeCatitoPadrao = 6;
    private Rigidbody2D rbCatito; //rigidbody = rb
    public PosicoesH posicaoAtualH;
    public PosicoesV posicaoAtualV;
    public Display orientacao;
    private int quantidadePraAndar = 1;
    private float quantidadePraAndarV = 1.5f;
    private CatitoColisao colisao;
    private Animator catitoAnim;
    private PlayerInput playerInput;
    private CatitoAtaque catitoAtaque;
    [SerializeField] private CameraTreme cameraTreme;

    void Start() {
        catitoAnim = this.GetComponent<Animator>();
        posicaoAtualH = PosicoesH.meio;
        posicaoAtualV = PosicoesV.meio;
        colisao = this.gameObject.GetComponent<CatitoColisao>();
        rbCatito = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        catitoAtaque = this.GetComponent<CatitoAtaque>();
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;

        if (SceneLoader.IsAcessibleScene()) {
            quantidadePraAndarV = 2f;
        } 

        switch(orientacao){
            case Display.horizontal:
                catitoAnim.SetInteger("Orientacao", 0);
            break;
            case Display.vertical:
                catitoAnim.SetInteger("Orientacao", 2);
            break;
        }
        if(StatusJogo.statusAtual == Status.inicial){
            catitoAnim.SetBool("gameplay", false);
        }else{
            catitoAnim.SetBool("gameplay", true);
        }

        this.AjustaVelocidade();
    }

    void Update() {
        if(StatusJogo.statusAtual == Status.inicial){
            catitoAnim.SetBool("gameplay", false);
        }else{
            catitoAnim.SetBool("gameplay", true);
            if(!colisao.estaAtordoado()){
                if(orientacao == Display.horizontal){
                    rbCatito.velocity = new Vector2(velocidadeCatito, 0);
                }
                else{
                    switch(rbCatito.velocity.y){
                        case >= 0:
                            rbCatito.velocity = new Vector2(0, velocidadeCatito);
                            break;
                        case < 0:
                            rbCatito.velocity = new Vector2(0, -velocidadeCatito);
                            break;
                    }
                }
            }
            
            if(playerInput.actions["Cima"].triggered && (orientacao == Display.horizontal)){
                switch(posicaoAtualH){
                    case PosicoesH.cima:
                        break;
                    case PosicoesH.meio:
                        this.tremeDash();
                        rbCatito.position += new Vector2(0, quantidadePraAndar);
                        posicaoAtualH = PosicoesH.cima;
                        break;
                    case PosicoesH.baixo:
                        this.tremeDash();
                        rbCatito.position += new Vector2(0, quantidadePraAndar);
                        posicaoAtualH = PosicoesH.meio;
                        break;
                }
            }

            if(playerInput.actions["Baixo"].triggered && (orientacao == Display.horizontal)){
                switch(posicaoAtualH){
                    case PosicoesH.cima:
                        this.tremeDash();
                        rbCatito.position += new Vector2(0, -quantidadePraAndar);
                        posicaoAtualH = PosicoesH.meio;
                        break;
                    case PosicoesH.meio:
                        this.tremeDash();
                        rbCatito.position += new Vector2(0, -quantidadePraAndar);
                        posicaoAtualH = PosicoesH.baixo;
                        break;       
                    case PosicoesH.baixo:
                        break;
                }
            }

            if(playerInput.actions["Esquerda"].triggered && (orientacao == Display.vertical)){
                switch(posicaoAtualV){
                    case PosicoesV.esquerda: 
                        break;
                    case PosicoesV.meio:
                        this.tremeDash();
                        rbCatito.position += new Vector2(-quantidadePraAndarV, 0);
                        posicaoAtualV = PosicoesV.esquerda;
                        break;
                    case PosicoesV.direita:
                        this.tremeDash();
                        rbCatito.position += new Vector2(-quantidadePraAndarV, 0);
                        posicaoAtualV = PosicoesV.meio;
                        break;
                }
            }

            if(playerInput.actions["Direita"].triggered && (orientacao == Display.vertical)){
                switch(posicaoAtualV){
                    case PosicoesV.esquerda: 
                        this.tremeDash();
                        rbCatito.position += new Vector2(quantidadePraAndarV, 0);
                        posicaoAtualV = PosicoesV.meio;
                        break;
                    case PosicoesV.meio:
                        this.tremeDash();
                        rbCatito.position += new Vector2(quantidadePraAndarV, 0);
                        posicaoAtualV = PosicoesV.direita;
                        break;
                    case PosicoesV.direita:
                        break;
                }
            }   
        }
    }

    void OnTriggerEnter2D(Collider2D corredor){
        switch (corredor.tag){
            case ("Horizontal"):
                orientacao = Display.horizontal;
                posicaoAtualH = PosicoesH.meio;
                catitoAnim.SetInteger("Orientacao", 0);
                rbCatito.velocity = new Vector2(velocidadeCatito, 0);
                corredor.GetComponent<Collider2D>().enabled = false;
                break;
            case ("VerticalPraBaixo"):
                orientacao = Display.vertical;
                posicaoAtualV = PosicoesV.meio;
                catitoAnim.SetInteger("Orientacao", 1);
                rbCatito.velocity = new Vector2(0, -velocidadeCatito);
                corredor.GetComponent<Collider2D>().enabled = false;

                break;
            case ("VerticalPraCima"):
                orientacao = Display.vertical;
                posicaoAtualV = PosicoesV.meio;
                catitoAnim.SetInteger("Orientacao", 2);
                rbCatito.velocity = new Vector2(0, velocidadeCatito);
                corredor.GetComponent<Collider2D>().enabled = false;

                break;
        }
    }

    void tremeDash(){
        if (SceneLoader.IsAcessibleScene()) {
        //
        } else {
            cameraTreme.Shake(0.1f, 2f, 2f);
        }
        
    }
    void SetVelocidadeInicial(){
        //FAZER ISSOOOOOOOOOOO
        //TEM Q SER DIFERENTE DEPENDENDO DA DIFICULDADE E MODO DE JOGO
    }
    void AjustaVelocidade(){


        string cenaNome = SceneManager.GetActiveScene().name;
        
        if (cenaNome=="CenaPrincipalInicial" || cenaNome=="CenaAcessivelInicial" ){
            PlayerPrefs.SetFloat("FasesPassadas", 0);
        
        }else{
            PlayerPrefs.SetFloat("FasesPassadas", PlayerPrefs.GetFloat("FasesPassadas")+1);
        }
        
        if(PlayerPrefs.GetFloat("FasesPassadas")>0 && PlayerPrefs.GetFloat("FasesPassadas")<4){
            velocidadeCatito = velocidadeCatitoPadrao * (1+(PlayerPrefs.GetFloat("FasesPassadas")/10));
            catitoAtaque.AjustaCooldown();
        }


    }
}
