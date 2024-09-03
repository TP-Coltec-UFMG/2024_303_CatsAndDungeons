using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaBotaoLuz : MonoBehaviour
{
    
    private Animator dificuldadeAnim;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        dificuldadeAnim = GetComponent<Animator>();
        canvasGroup = GetComponentInParent<CanvasGroup>();
    }

    // void OnMouseEnterEvent(){
    //     AcenderLuz();
    // }

    // void MouseOutEvent(){
    //     ApagarLuz();
    // }
    public void AcenderLuz(){
        if(canvasGroup.alpha>=0.9f){
            dificuldadeAnim.SetBool("Acesa", true);
        }
    }

    public void ApagarLuz(){
        dificuldadeAnim.SetBool("Acesa", false);
    }
}
