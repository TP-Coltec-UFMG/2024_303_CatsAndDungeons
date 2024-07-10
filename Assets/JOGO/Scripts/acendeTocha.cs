using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acendeTocha : MonoBehaviour
{

    private Animator tochaAnim; 
    // Start is called before the first frame update
    void Start()
    {
        tochaAnim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("MainCamera")) {
            tochaAnim.SetTrigger("Acender");
        }
    }
}
