using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligaMenuAtras : MonoBehaviour
{
    GameObject menuT;

    // Start is called before the first frame update
    void Start(){
        menuT = GameObject.Find("MenuAtras");
    }

    public void DesligaMenu(){
        menuT.SetActive(false);
    }
}