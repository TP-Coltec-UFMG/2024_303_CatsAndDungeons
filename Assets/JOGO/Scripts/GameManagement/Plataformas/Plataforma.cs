using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma {
    [SerializeField] public GameObject objetoPlataforma;
    [SerializeField] public bool foiSpawnada = false;

    public Plataforma(GameObject objetoPlat){
        this.objetoPlataforma = objetoPlat;
    }
}
