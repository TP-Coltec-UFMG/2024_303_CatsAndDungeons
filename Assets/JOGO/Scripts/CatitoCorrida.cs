using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PosicoesH{cima = 1, meio = 0, baixo = -1}
public enum PosicoesV{esquerda = 1, meio = 0, direita = -1}
public enum Display{horizontal, vertical}

public class CatitoCorrida : MonoBehaviour
{
    public float velocidadeCatito = 100f;
    private Rigidbody2D rbCatito; //rigidbody = rb
    public PosicoesH posicaoAtualH;
    public PosicoesV posicaoAtualV;
    public Display orientacao;
    private int quantidadePraAndar;
    private const float quantidadePraAndarV = 1.5f;
    private CatitoColisao colisao;
    private Animator catitoAnim;
    private PlayerInput playerInput;
    [SerializeField] private CameraTreme cameraTreme;

    void Start() {
        catitoAnim = this.GetComponent<Animator>();
        posicaoAtualH = PosicoesH.meio;
        posicaoAtualV = PosicoesV.meio;
        colisao = this.gameObject.GetComponent<CatitoColisao>();
        rbCatito = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        int cenaAtual = SceneManager.GetActiveScene().buildIndex;

        print(cenaAtual);
        if (cenaAtual == 2) {
            quantidadePraAndar = 2;
        } else {
            quantidadePraAndar = 1;
        }

        switch(orientacao){
            case Display.horizontal:
                catitoAnim.SetInteger("Orientacao", 0);
            break;
            case Display.vertical:
                catitoAnim.SetInteger("Orientacao", 2);
            break;
        }
    }

    // Update is called once per frame
    void Update() {
        if(!colisao.estaAtordoado()){
            if(orientacao == Display.horizontal){
                //rbCatito.velocity = new Vector2(velocidadeCatito * Time.deltaTime, 0);
                rbCatito.velocity = new Vector2(velocidadeCatito, 0);
            }
            else{
                switch(rbCatito.velocity.y){
                    case >= 0:
                        //rbCatito.velocity = new Vector2(0, velocidadeCatito * Time.deltaTime);
                        rbCatito.velocity = new Vector2(0, velocidadeCatito);
                        break;
                    case < 0:
                        rbCatito.velocity = new Vector2(0, -velocidadeCatito);
                        //rbCatito.velocity = new Vector2(0, -velocidadeCatito* Time.deltaTime);
                        break;
                }
            }
        }
        if(playerInput.actions["Cima"].triggered && (orientacao == Display.horizontal)){
            switch(posicaoAtualH){
                case PosicoesH.cima:
                    //faz nada
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
                    //faz nada
                    break;
            }
        }

        if(playerInput.actions["Esquerda"].triggered && (orientacao == Display.vertical)){
            switch(posicaoAtualV){
                case PosicoesV.esquerda: 
                    //faz nada
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
                    //faz nada
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D corredor){
        switch (corredor.tag){
            case ("Horizontal"):
                orientacao = Display.horizontal;
                posicaoAtualH = PosicoesH.meio;
                catitoAnim.SetInteger("Orientacao", 0);
                //rbCatito.velocity = new Vector2(velocidadeCatito * Time.deltaTime, 0);
                rbCatito.velocity = new Vector2(velocidadeCatito, 0);

                break;
            case ("VerticalPraBaixo"):
                orientacao = Display.vertical;
                posicaoAtualV = PosicoesV.meio;
                catitoAnim.SetInteger("Orientacao", 1);
                //rbCatito.velocity = new Vector2(0, -velocidadeCatito*Time.deltaTime);
                rbCatito.velocity = new Vector2(0, -velocidadeCatito);
                break;
            case ("VerticalPraCima"):
                orientacao = Display.vertical;
                posicaoAtualV = PosicoesV.meio;
                catitoAnim.SetInteger("Orientacao", 2);
                //rbCatito.velocity = new Vector2(0, velocidadeCatito*Time.deltaTime);
                rbCatito.velocity = new Vector2(0, velocidadeCatito);
                break;
        }
    }

    void tremeDash(){
    	int cenaAtual = SceneManager.GetActiveScene().buildIndex;
    	print(cenaAtual);
        if (cenaAtual == 2) {
        //
        } else {
            cameraTreme.Shake(0.1f, 2f, 2f);
        }
        
    }
}
