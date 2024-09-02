using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTroca : MonoBehaviour
{
    [SerializeField] private Animator animaCamera;
    private GameObject menuP;
    private GameObject menuA;
    private GameObject menuR;
    private GameObject menuT;
    
    // Start is called before the first frame update
    void Start(){
        menuP = GameObject.Find("MenuPrincipal");
        menuA = GameObject.Find("MenuAjustes");
        menuR = GameObject.Find("MenuRemapeamento");
        menuT = GameObject.Find("MenuTutorial");
        
        menuA.SetActive(false);
        menuR.SetActive(false);
        menuT.SetActive(false);
    }

    public void PraDireita(int botaoClicou){
        if (botaoClicou == 1) {//Principal>Ajustes
            animaCamera.SetBool("FoiNoMenu", true);
            menuA.SetActive(true);
            menuP.SetActive(false);
        } else {
            animaCamera.SetBool("FoiNoMenu", false);
        }
        if (botaoClicou == 2) {//Ajustes>Remapeamento
            animaCamera.SetBool("FoiNaDireita", true);
            menuR.SetActive(true);
            menuA.SetActive(false);
        } else {
            animaCamera.SetBool("FoiNaDireita", false);
        }
        if((botaoClicou != 1) && (botaoClicou != 2)){//Tutorial>Principal
            menuP.SetActive(true);
            menuT.SetActive(false);
        }
        animaCamera.SetBool("Direita", true);
        animaCamera.SetBool("Esquerda", false);
    }

    public void PraEsquerda(int botaoClicou){
        if (botaoClicou == 1) {//Principal>Tutorial
            animaCamera.SetBool("FoiNoMenu", true);
            menuT.SetActive(true);
            menuP.SetActive(false);
        } else {
            animaCamera.SetBool("FoiNoMenu", false);
        }
        if (botaoClicou == 2) {//Ajustes>Principal
            animaCamera.SetBool("FoiNaDireita", true);
            menuP.SetActive(true);
            menuA.SetActive(false);
        } else {
            animaCamera.SetBool("FoiNaDireita", false);
        }
        if((botaoClicou != 1) && (botaoClicou != 2)){//Remapeamento>Ajustes
            menuA.SetActive(true);
            menuR.SetActive(false);
        }
        animaCamera.SetBool("Esquerda", true);
        animaCamera.SetBool("Direita", false);
    }

    public void AtivaTutorial(){
        menuT.SetActive(true);
    }
    public void DestivaTutorial(){
        menuT.SetActive(false);
    }
}