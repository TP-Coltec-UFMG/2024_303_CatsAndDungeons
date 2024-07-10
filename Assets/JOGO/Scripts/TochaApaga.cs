using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TochaApaga : MonoBehaviour
{
    // Start is called before the first frame update]
    private Light2D luzinha;
    [SerializeField][Range(0, 100)] private int IntensidadeLuz; 
    public Animator animator;
    //[SerializeField] float IntensidadeLuz; 

    void Start()
    {
        luzinha = GetComponentInChildren<Light2D>();
        animator = GetComponentInChildren<Animator>();
        luzinha.intensity = IntensidadeLuz;
    }

    // Update is called once per frame

    void OnMouseOver(){ //quando o mouse estiver em cima da tocha
        if(Input.GetMouseButtonDown(0)){ //quando mouse clicar(enquanto estiver em cima da tocha, já q tá dentro dessa função)
            if(animator.GetBool("Ligada")){ //se a intensidade da luzinha igual a intensidade normal, ele deixa em zero. Se for igual a zero, deixa em 53
                animator.SetBool("Ligada", false);
            } 
            else{
                animator.SetBool("Ligada", true);
            }
            
        }
    }
}
