using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CatitoAtaque : MonoBehaviour
{
    // Start is called before the first frame update
    
    //private PlayerInput playerInput; 
    private Animator catitoAnim;

    [SerializeField] private Image espadaIcon;
    private PlayerInput playerInput;

    [SerializeField] private CameraTreme cameraTreme;

    private GameObject colisorAtaque;

    private bool atacando;
    private bool podeAtacar = false;

    private float ataqueCooldownTimer;
    private const float tempoMaximoAtaque = 0.2f;
    private float cooldownAtaque = 1.8f;
    private float cooldownAtaquePadrao = 1.8f;
    //private Collider2D catitoColider;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        catitoAnim = this.GetComponent<Animator>();
        colisorAtaque = this.transform.GetChild(0).gameObject;
        colisorAtaque.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ataqueCooldownTimer += Time.deltaTime;

        if (ataqueCooldownTimer > cooldownAtaque){
            espadaIcon.enabled = true;
            podeAtacar = true;
        }
        else{
            espadaIcon.enabled = false;
            podeAtacar = false;
        }

        if (playerInput.actions["Ataque"].triggered && podeAtacar){
            catitoAnim.SetTrigger("Atacar");
            StartCoroutine(atacar());
        }
    }

    IEnumerator atacar()
    {
        
        ataqueCooldownTimer = 0;
        cameraTreme.Shake(0.1f, 5f, 5f);
        this.SortearSomAtaque();
        yield return new WaitForSeconds(0.2f);
        atacando = true;
        colisorAtaque.SetActive(atacando); //ativa o collider de ataque

        yield return new WaitForSeconds(tempoMaximoAtaque);
        atacando = false;
        colisorAtaque.SetActive(atacando); //desativa o collider de ataque

    }

    private void SortearSomAtaque(){
        

        switch(Random.Range(0, 2)){//retorna um inteiro entre 0 e 1
            case 0:
                GerenciadorAudio.instance.TocarSFX("Ataque");
                break;
            case 1:
                GerenciadorAudio.instance.TocarSFX("AtaqueB");
                break;
            default:
                print("Sortearam o som meio errado aqui");
                break;
        }
    }

    public void AjustaCooldown(){      
        CatitoCorrida catitoCorrida = this.GetComponent<CatitoCorrida>();
        cooldownAtaque = cooldownAtaquePadrao * (catitoCorrida.velocidadeCatitoPadrao/catitoCorrida.velocidadeCatito);
    }
}
