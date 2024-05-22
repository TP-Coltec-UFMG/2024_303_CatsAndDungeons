using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraEstrela : MonoBehaviour
{
    private RectTransform[] estrelaRECT = new RectTransform[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizaGiro(Slider slider){
        estrelaRECT = slider.GetComponentsInChildren<RectTransform>();


        for(int i = 0; i < estrelaRECT.Length; i++){
            if(estrelaRECT[i].CompareTag("Estrela")){
                estrelaRECT[i].rotation = new Quaternion(0f, 0f, (float)slider.value, 0f);
            }
        }
    }
}
