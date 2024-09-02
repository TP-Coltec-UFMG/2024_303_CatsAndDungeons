using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Dialogo{
    public class CaixaDialogo : MonoBehaviour
    {
        
        void Start()
        {
            StartCoroutine(SequenciaDialogo());
        }

        private IEnumerator SequenciaDialogo(){
            this.DesativarTodosDialogos();
            for(int i = 0; i<transform.childCount;i++){

                //desativa todos os dialogos a cada novo dialogo que for sendo mostrado
                

                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(()=> transform.GetChild(i).GetComponent<ClasseBaseDialogo>().DialogoConcluido); 
                StartCoroutine(DesativarDialogo(transform.GetChild(i).gameObject.GetComponent<Animator>()));

                yield return new WaitForSeconds(1.5f);
            }
            
            yield return new WaitForSeconds(1.5f);
            this.AcabarCena();
        }

        private void DesativarTodosDialogos(){
            for(int i = 0; i<transform.childCount;i++){
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        
        private IEnumerator DesativarDialogo(Animator dialogoAnim){
            dialogoAnim.SetTrigger("Sumir");
            yield return new WaitForSeconds(1f);
            dialogoAnim.gameObject.SetActive(false);
        }
        private void AcabarCena(){
            if(SceneManager.GetActiveScene().name=="AnimacaoInicial"){
                StartCoroutine(FindFirstObjectByType<SceneLoaderGame>().LoadScene("CenaPrincipalInicial"));
            }else{
                StartCoroutine(FindFirstObjectByType<SceneLoaderGame>().LoadScene("Menu"));
            }
        }
        // private IEnumerator AtivarDialogo(){
            
        //     yield return new WaitForSeconds(1f);

        // }
    }
}
