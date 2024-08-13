using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicoBrain : MonoBehaviour
{
    public static CinematicoBrain instance { get; private set; }
    private Animator animatorCinematica;
    void Awake(){
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            this.gameObject.SetActive(true);
            animatorCinematica = this.GetComponent<Animator>();
        } else {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    public void LigarCinematica(){
        animatorCinematica.SetBool("cinema", true);
    }

    public void DesligarCinematica(){
        animatorCinematica.SetBool("cinema", false);
    }
}
