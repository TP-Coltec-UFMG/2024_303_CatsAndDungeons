using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeletorElementos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colider){
        if(colider.gameObject.GetComponent<AudioSource>() != null){
            Destroy(colider.gameObject);
        }
    }
}
