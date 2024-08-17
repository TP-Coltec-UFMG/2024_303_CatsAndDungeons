using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            CinematicoBrain.instance.LigarCinematica();
            yield return new WaitForSeconds(2f);
            StartCoroutine(FindFirstObjectByType<SceneLoaderGame>().LoadScene("CenaPrincipal"));
        }

        private void DesativarTodosDialogos(){
            for(int i = 0; i<transform.childCount;i++){
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        private IEnumerator AtivarDialogo(){
            
            yield return new WaitForSeconds(1f);

        }
        private IEnumerator DesativarDialogo(Animator dialogoAnim){
            dialogoAnim.SetTrigger("Sumir");
            yield return new WaitForSeconds(1f);
            dialogoAnim.gameObject.SetActive(false);
        }
    }
}
