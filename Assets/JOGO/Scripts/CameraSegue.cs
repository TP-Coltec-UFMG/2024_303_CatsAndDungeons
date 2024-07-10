using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{

    [SerializeField] private GameObject GOcatito;
    private Transform euMesmo;
    [SerializeField] private CatitoCorrida catito;

    // Start is called before the first frame update
    void Start(){
        euMesmo = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        if (catito.orientacao == Display.horizontal){ 
            transform.position = new Vector3(GOcatito.transform.position.x + 2.88f, euMesmo.transform.position.y, -10); //atualiza a posicao X da camera
            transform.localEulerAngles = new Vector3(GOcatito.transform.localEulerAngles.x, GOcatito.transform.localEulerAngles.y, GOcatito.transform.localEulerAngles.z);
        }
        if (catito.orientacao == Display.vertical){
            transform.position = new Vector3(euMesmo.transform.position.x, GOcatito.transform.position.y, -10); //atualiza a posicao Y da camera
            transform.localEulerAngles = new Vector3(GOcatito.transform.localEulerAngles.x, GOcatito.transform.localEulerAngles.y, GOcatito.transform.localEulerAngles.z);

        }
    }
}
