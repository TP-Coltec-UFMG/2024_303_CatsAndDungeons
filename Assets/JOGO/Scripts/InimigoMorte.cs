using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMorte : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator inimigoAnim;
    private Transform inimigoPai;
    private Collider2D inimigoCollider;
    public bool morto {get; private set;} = false;
    private void Start()
    {
        inimigoPai = this.transform.parent;
        inimigoCollider = this.GetComponent<Collider2D>();
        inimigoAnim = this.GetComponent<Animator>();
    }
    public void Morrer() {

        this.morto = true;
        inimigoCollider.enabled = false;
        inimigoAnim.SetTrigger("Morrer");
        StartCoroutine(MorteTime());
    }

    private IEnumerator MorteTime(){
        
        
        yield return new WaitForSeconds(1);
        for (int i = 1; i < inimigoPai.childCount; i++) { //pra cada filho do pai do inimigo, excluindo o proprio inimigo, desative o gameobject
            this.inimigoPai.GetChild(i).gameObject.SetActive(false);
        }
        Destroy(this.inimigoPai.gameObject);

    }
}
