using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderGame : MonoBehaviour {
    [SerializeField] private Toggle toggleAB;
    public static string cenaPraCarregar, cenaAtual;
    private bool modoAcessivel;
    [SerializeField] private Animator transitorAnim;
    [SerializeField] private Animator dificuldadeAnim;
    [SerializeField] private Animator botoesIniciaisAnim;
    Animator catitoAnim;
    void Start() {
        modoAcessivel = intToBool(PlayerPrefs.GetInt("AudioBinaural"));
        cenaAtual = SceneManager.GetActiveScene().name;
        if(toggleAB!=null){
            toggleAB.isOn = modoAcessivel;
        }
        if(dificuldadeAnim!=null){
            dificuldadeAnim.gameObject.SetActive(false);
        }
        
        if(GameObject.FindGameObjectsWithTag("CatitoMenu")[0]!=null){
            catitoAnim = GameObject.FindGameObjectsWithTag("CatitoMenu")[0].GetComponent<Animator>();
        }
    }
    public void IniciarJogo(){
        PlayerPrefs.SetString("Modo de jogo", "Historia");
        if (modoAcessivel){
            cenaPraCarregar = "CenaAcessivelInicial";
        } else if(cenaAtual=="AnimacaoInicial"){
            cenaPraCarregar = "CenaPrincipalInicial";
        }else{
            cenaPraCarregar = "AnimacaoInicial";
        }

        StartCoroutine(this.ApareceBotoesDificuldade());
    }
    public void IniciarJogoInfinito(){
        PlayerPrefs.SetString("Modo de jogo", "Infinito");    
        if (modoAcessivel){
            cenaPraCarregar = "CenaAcessivelInicial";
        } else {
            cenaPraCarregar = "CenaPrincipalInicial";
        }

        StartCoroutine(this.ApareceBotoesDificuldade());
    }

    private IEnumerator ApareceBotoesDificuldade(){
        botoesIniciaisAnim.SetBool("iniciado", false);
        catitoAnim.SetTrigger("Sumir");
        yield return new WaitForSeconds(0.5f);

        botoesIniciaisAnim.gameObject.SetActive(false);
        dificuldadeAnim.gameObject.SetActive(true);
        dificuldadeAnim.SetBool("iniciado", true);
    }
    public void ExitGame(){
        StartCoroutine(ExitGameCoro());
    }
    public IEnumerator LoadScene(string cena) {
        transitorAnim.SetTrigger("Comecar");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(cena);
    }
    public IEnumerator LoadScene() {
        transitorAnim.SetTrigger("Comecar");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(cenaPraCarregar);
    }
    public IEnumerator ExitGameCoro() {
        transitorAnim.SetTrigger("Comecar");

        yield return new WaitForSeconds(1f);

        Application.Quit();
    }
    public void ToggleAudioBinaural(){
        modoAcessivel = !modoAcessivel;
        PlayerPrefs.SetInt("AudioBinaural", boolToInt(modoAcessivel));
        print(modoAcessivel);
    }

    public static bool intToBool(int integer){
        if(integer==1){
            return true;
        }else{
            return false;
        }
    }
    public static int boolToInt(bool boolean){
        if (boolean){
            return 1;
        }else{
            return 0;
        }
    }
}
