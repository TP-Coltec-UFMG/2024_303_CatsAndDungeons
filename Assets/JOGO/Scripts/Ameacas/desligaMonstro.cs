using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desligaMonstro : MonoBehaviour
{
    Animator monstroAnim;
    Animator cam;
    
    [SerializeField] private CatitoColisao colisao;


    // Start is called before the first frame update
    void Start(){
        monstroAnim = this.gameObject.GetComponent<Animator>();
    }
    void Update(){
        monstroAnim.SetBool("Atordoado", colisao.estaAtordoado());
    }
    public void DesligaMonstro(){
        cam = GameObject.Find("Main camera").GetComponent<Animator>();
        cam.SetBool("querFixar", true);
        monstroAnim.SetBool("Atordoado", false);
    }
}
