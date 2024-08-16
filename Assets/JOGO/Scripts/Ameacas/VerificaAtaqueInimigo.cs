using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaAtaqueInimigo : MonoBehaviour
{

    private bool Atacando  = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    

    public bool IsAlreadyAttacking(){
        return this.Atacando;
    }

    public void AttackStatus(bool status){
        this.Atacando = status;
    }
}
