using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuGameOver;

    [SerializeField] Transform catitoTransform;
    private Vector2 posicaoInicial;
    [SerializeField] private CatitoColisao catitoColisao;

    [SerializeField] private CatitoCorrida catitoCorrida;

    private Pontuador pontuador;

    [SerializeField] private Animator monstroAnim;

    [SerializeField] private desligaMonstro monstro;

    // Start is called before the first frame update
    void Start(){
        menuGameOver.SetActive(false);
        menuPausa.SetActive(false);
        pontuador = this.GetComponent<Pontuador>();
        posicaoInicial = this.catitoColisao.posicaoInicial;
        
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPausa.activeInHierarchy){
            PausarJogo();
        }else if(Input.GetKeyDown(KeyCode.Escape)){
            DespausarJogo();
        }
    }

    public void PausarJogo(){
    	monstroAnim.gameObject.SetActive(false);
    	menuPausa.SetActive(true);
        GerenciadorAudio.instance.PausarSons();
    	Time.timeScale = 0;
    }

    public void DespausarJogo(){
    	monstroAnim.gameObject.SetActive(true);
        menuGameOver.SetActive(false);
        menuPausa.SetActive(false);
        GerenciadorAudio.instance.ContinuarSons();
        Time.timeScale = 1;
    }
   
    public void ReiniciaJogo(){

        
        if(SceneLoader.IsAcessibleScene()){
            SceneManager.LoadScene("CenaAcessivel", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("CenaPrincipal", LoadSceneMode.Single);
        }
        Pontuador.instance.zeraPontuacao();
        Time.timeScale = 1;
        /*
        menuGameOver.SetActive(false);
        menuPausa.SetActive(false);
        
        monstro.DesligaMonstro();
        monstroAnim.SetBool("Atordoado", false);
        catitoTransform.position = this.posicaoInicial;
        catitoCorrida.orientacao = Display.horizontal;
        catitoCorrida.posicaoAtualH = PosicoesH.meio;
        catitoCorrida.posicaoAtualV = PosicoesV.meio;

        pontuador.zeraPontuacao();
        */
    }

    public void GameOver(){
        FindFirstObjectByType<GameOverMenu>(FindObjectsInactive.Include).PreenchePainel();
        //substituirrr por preenchePainel 
        menuGameOver.SetActive(true);
        monstroAnim.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
