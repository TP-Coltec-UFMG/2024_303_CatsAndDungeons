using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrastaMontanhas : MonoBehaviour
{

    [SerializeField] private RawImage imagemScrollavel;
    // Start is called before the first frame update
    void Start()
    {
        imagemScrollavel = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rect temporario = new Rect(imagemScrollavel.uvRect);  
        //cria um retangulo com as proporções do uvRentagulo do Raw image

        temporario.x += 0.1f * Time.deltaTime;
        imagemScrollavel.uvRect = temporario;
        //acrescenta no x do retangulo que criamos e depois armazena

    }
}
