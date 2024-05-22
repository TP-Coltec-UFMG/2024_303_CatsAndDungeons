using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTroca : MonoBehaviour
{
    [SerializeField] private Animator animaCamera;

    public void PraEsquerda(int botaoClicou){
        if (botaoClicou == 1) {
            animaCamera.SetBool("FoiNoMenu", true);
        } else {
            animaCamera.SetBool("FoiNoMenu", false);
        }
        if (botaoClicou == 2) {
            animaCamera.SetBool("FoiNaDireita", true);
        } else {
            animaCamera.SetBool("FoiNaDireita", false);
        }
        animaCamera.SetBool("Esquerda", true);
        animaCamera.SetBool("Direita", false);
    }

    public void PraDireita(int botaoClicou){
        if (botaoClicou == 1) {
            animaCamera.SetBool("FoiNoMenu", true);
        } else {
            animaCamera.SetBool("FoiNoMenu", false);
        }
        if (botaoClicou == 2) {
            animaCamera.SetBool("FoiNaDireita", true);
        } else {
            animaCamera.SetBool("FoiNaDireita", false);
        }
        animaCamera.SetBool("Direita", true);
        animaCamera.SetBool("Esquerda", false);
    }
}