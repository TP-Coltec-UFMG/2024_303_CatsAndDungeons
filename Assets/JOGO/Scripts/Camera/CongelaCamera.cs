using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongelaCamera : MonoBehaviour
{
    private Rigidbody2D rbCamera;
    [SerializeField] private CatitoCorrida catito;
    [SerializeField] private Rigidbody2D rbCatito;
    
    // Start is called before the first frame update
    void Start(){
        rbCamera = this.GetComponent<Rigidbody2D>();
        print(rbCamera);
    }

    // Update is called once per frame
    void Update(){
        rbCamera.velocity = rbCatito.velocity;
        if(catito.orientacao == Display.horizontal){
            rbCamera.constraints = RigidbodyConstraints2D.None;
            rbCamera.constraints = RigidbodyConstraints2D.FreezePositionY;

        }
        if(catito.orientacao == Display.vertical){
            rbCamera.constraints = RigidbodyConstraints2D.None;
            rbCamera.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
