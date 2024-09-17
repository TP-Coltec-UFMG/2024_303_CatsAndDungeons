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
        print("pausei essa bomba");
        PlayerPrefs.Save();
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

        print("tentei reiniciar aqui");
        menuGameOver.SetActive(false);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(SceneLoader.IsAcessibleScene()){
            SceneManager.LoadScene("CenaAcessivelInicial", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("CenaPrincipalInicial", LoadSceneMode.Single);
        }
        //StartCoroutine(RestaurarTimeScale());
        Pontuador.instance.ZeraPontuacao();
        
}

    // IEnumerator RestaurarTimeScale(){
    //     yield return new WaitForSecondsRealtime(0.2f);

    //     Time.timeScale = 1;
    // }
   
    public void GameOver(){
        
        FindFirstObjectByType<GameOverMenu>(FindObjectsInactive.Include).PreenchePainel();
        PlayerPrefs.Save();
        //substituirrr por preenchePainel 
        menuGameOver.SetActive(true);
        monstroAnim.gameObject.SetActive(false);
        print("gameOver mano, vou pausar");
        Time.timeScale = 0;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    // Restaurar o Time.timeScale assim que a nova cena carregar
    Time.timeScale = 1;

    SceneManager.sceneLoaded -= OnSceneLoaded;
}
}
