using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    private int NumeroCenasJogo = 6;
    private const int indexMaximoPadrao = 4;
    private const int indexMaximoAcessivel = 7;
    private const int tiposDeJogo = 2;
    [SerializeField] Animator transitorAnim;
    void Start()
    {
        //pega a quantidade de cenas de jogo que tem
        

        // for(int i = 0; i< SceneManager.sceneCount; i++){
        //     Debug.Log("indice de cena verificado: "+ i);
        //     if(SceneManager.GetSceneByBuildIndex(i)!=null){
        //         Debug.Log(SceneManager.GetSceneByBuildIndex(i));
                
        //         if(SceneManager.GetSceneByBuildIndex(i).name.StartsWith("Cena")){
        //             NumeroCenasJogo++;
        //         }
        //     }else{
        //         Debug.Log("Deu null aq na cena");
        //     }  
        // }
        
        //IndexMaximo é o último index de gameplay de cada tipo de cena, acessivel e padrao
        //Pega o index da cenaPrincipal, e soma com NumeroCenasJogo/2
        //divide-se pela quantidade de tipos de jogos
        //subtrai-se 1 para desconsiderar a propria cena
        //indexMaximoPadrao = SceneManager.GetSceneByName("CenaPrincipal").buildIndex + 2;
        //indexMaximoAcessivel = SceneManager.GetSceneByName("CenaAcessivel").buildIndex + 2;

    }
     public IEnumerator LoadScene() {
        int index = SceneManager.GetActiveScene().buildIndex;
        
        transitorAnim.SetTrigger("Comecar");

        yield return new WaitForSeconds(1f);


        if(index != indexMaximoAcessivel && index != indexMaximoPadrao){
            print("so passa pro proximo");
            SceneManager.LoadScene((index+1), LoadSceneMode.Single);
        }else{
            print(PlayerPrefs.GetString("Modo de jogo"));
            if(PlayerPrefs.GetString("Modo de jogo")=="Historia"){
                SceneManager.LoadScene("AnimacaoFinal");
            }else{
                SceneManager.LoadScene((index-(NumeroCenasJogo/2)), LoadSceneMode.Single);
            }
        }        
    }
    public static bool IsGameScene(){
        return SceneManager.GetActiveScene().name.StartsWith("Cena");
    }
    public static bool IsAnimScene(){
        return SceneManager.GetActiveScene().name.StartsWith("Animacao");
    }

    public static bool IsGameScene(Scene scene){
        return scene.name.StartsWith("Cena");
    }

    public static bool IsAcessibleScene(){
        return SceneManager.GetActiveScene().name.Contains("Acessivel");
    }
    public static bool IsAcessibleScene(Scene scene){
        return scene.name.Contains("Acessivel");
    }
}