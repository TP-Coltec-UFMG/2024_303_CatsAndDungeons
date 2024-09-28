using UnityEngine;
public class ControleBotoesMobile : MonoBehaviour
{

    private CatitoCorrida catitoCorrida;
    
    private CatitoAtaque catitoAtaque;

    private Menus menusControle;
    // Start is called before the first frame update
    private void Start(){
        print(PlayerPrefs.GetInt("MobileMode"));
        catitoCorrida = FindObjectOfType<CatitoCorrida>();
        catitoAtaque = catitoCorrida.gameObject.GetComponent<CatitoAtaque>();
        menusControle = FindObjectOfType<Menus>();
        AjustaControle();
    }

    // Update is called once per frame
    public void AjustaControle() {
        print("tentei ajeitar");
        if (PlayerPrefs.GetInt("MobileMode", 0) == 1) {
            print("ajeitei");
            if (catitoCorrida.orientacao == Display.horizontal)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        
    }

    public void MoverCima() {
        catitoCorrida.MoverCima();
    }
    public void MoverBaixo() {
        catitoCorrida.MoverBaixo();
    }
    public void MoverDireita() {
        catitoCorrida.MoverDireita();
    }
    public void MoverEsquerda() {
        catitoCorrida.MoverEsquerda();
    }
    public void Atacar() {
        catitoAtaque.SimplifiedAtacar();
    }
    public void RemotePausar() {
        menusControle.PausarJogo();
    }
}
