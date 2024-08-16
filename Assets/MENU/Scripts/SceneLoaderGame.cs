using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderGame : MonoBehaviour {
    [SerializeField] private Toggle toggleAB;
    private string cenaPraCarregar, cenaAtual;
    private bool modoAcessivel;
    [SerializeField] private Animator transitorAnim;

    void Start() {
        modoAcessivel = intToBool(PlayerPrefs.GetInt("AudioBinaural"));
        cenaAtual = SceneManager.GetActiveScene().name;
        if(toggleAB!=null){
            toggleAB.isOn = modoAcessivel;
        }
    }
    public void IniciarJogo(){
        PlayerPrefs.SetString("Modo de jogo", "Historia");
        if (modoAcessivel){
            cenaPraCarregar = "CenaAcessivel";
        } else if(cenaAtual=="AnimacaoInicial"){
            cenaPraCarregar = "CenaPrincipal";
        }else{
            cenaPraCarregar = "AnimacaoInicial";
        }

        StartCoroutine(LoadScene(cenaPraCarregar));
    }
    public void IniciarJogoInfinito(){
        PlayerPrefs.SetString("Modo de jogo", "Infinito");    
        if (modoAcessivel){
            cenaPraCarregar = "CenaAcessivel";
        } else {
            cenaPraCarregar = "CenaPrincipal";
        }

        StartCoroutine(LoadScene(cenaPraCarregar));
    }

    public IEnumerator LoadScene(string cena) {
        
        transitorAnim.SetTrigger("Comecar");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(cena);

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
