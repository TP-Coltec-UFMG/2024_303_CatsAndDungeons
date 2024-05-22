using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class daltonismoToggle : MonoBehaviour
{
    // Start is called before the first frame update

    private Toggle toggleDalt;
    [SerializeField] private TMP_Dropdown dropdownDalt;
    private TMP_Text textDalt;
    void Start()
    {
        toggleDalt = this.GetComponent<Toggle>();
        textDalt = dropdownDalt.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aoTrocarValor()
    {
        dropdownDalt.interactable = (toggleDalt.isOn);
        if (dropdownDalt.interactable){
            textDalt.alpha = 255;
        }
        else
        {
            textDalt.alpha = 0.33f;
        }
    }
}
