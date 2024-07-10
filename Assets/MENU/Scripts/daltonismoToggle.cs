using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
public class daltonismoToggle : MonoBehaviour
{
    // Start is called before the first frame update

    private Toggle toggleDalt;
    [SerializeField] private TMP_Dropdown dropdownDalt;
    private TMP_Text textDalt;
    [SerializeField] RenderPipelineAsset URP;

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
        
        if (toggleDalt.isOn)
        {
            GraphicsSettings.defaultRenderPipeline = null;
            
        }
        else
        {
            GraphicsSettings.defaultRenderPipeline = URP;
            PlayerPrefs.SetInt("Daltonismo", 0);
        }
        
        
	dropdownDalt.interactable = (toggleDalt.isOn);
        //deixar texto transparente
        if (dropdownDalt.interactable){
            textDalt.alpha = 255;
        }
        else
        {
            textDalt.alpha = 0.33f;
        }
    }
}
