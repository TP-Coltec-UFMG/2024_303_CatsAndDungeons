using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletorPlataforma : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.CompareTag("Plataforma")){
            Destroy(colisor.gameObject);
        }
    }
}