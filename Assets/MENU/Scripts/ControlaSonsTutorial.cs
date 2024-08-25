using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlaSonsTutorial : MonoBehaviour
{
    private AudioSource audioSource;

    public void AtivaSom(){
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        StartCoroutine(DesativaSom());
    }

    IEnumerator DesativaSom(){
        yield return new WaitForSeconds(1f);
        while (true) {
            if (this.gameObject.transform.childCount == 1) {
                print("false");
                audioSource.enabled = false;
                break;
            }
            yield return null;
        }
    }
}