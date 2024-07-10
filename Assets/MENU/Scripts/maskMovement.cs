using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class maskMovement : MonoBehaviour
{


    [SerializeField] private GameObject brilho;
    private float timer = 0;
    private Rigidbody2D objectRb;
    private Quaternion rotation;
    // Update is called once per frame

    void Start()
    {
    	Time.timeScale = 1;
        Quaternion rotation = Quaternion.Euler(0, 0, 30);

        //RectTransform rectTransform = this.GetComponent<RectTransform>();
        //rectTransform.localEulerAngles = new Vector3(0, 0, 30);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 4) //a cada quatro segundos
        {
            timer = 0; //zera o timer

            //se tiver mais de uma Imagem nos filhos do objeto q contem o script...
            if(GetComponentsInChildren<Image>().Length > 1)
            {
                //se o segundo objeto tem a tag Reflexo...
                if (GetComponentsInChildren<Image>()[1].gameObject.CompareTag("Reflexo"))
                {
                    //deleta todos os GameObjects com imagem começando pelo segundos, pq o primeiro é a própria logo
                    for(int i = 1; i < GetComponentsInChildren<Image>().Length; i++)
                    {
                        Destroy(GetComponentsInChildren<Image>()[i].gameObject);
                    }
                }
            }
            objectRb = Instantiate(brilho, new Vector3(250, 4, 0), rotation).GetComponent<Rigidbody2D>(); //cria um reflexo novo
            objectRb.gameObject.transform.SetParent(transform, false); //faz com que o objeto seja filho do portador do código 

            objectRb.gameObject.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, 30);
            objectRb.velocity = new Vector2(-25, 0); //atualiza a velocidade do gameObject
        }
    }
}
