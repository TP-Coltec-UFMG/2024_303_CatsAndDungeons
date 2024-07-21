using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
public class daltonismoToggle : MonoBehaviour
{

    private Toggle toggleDalt;
    [SerializeField] private TMP_Dropdown dropdownDalt;
    private TMP_Text textDalt;
    [SerializeField] RenderPipelineAsset URP;

    void Awake()
    {
        this.toggleDalt = this.GetComponent<Toggle>();
        this.textDalt = dropdownDalt.GetComponentInChildren<TMP_Text>();

        if (PlayerPrefs.GetInt("Daltonismo") == 1)
        {
            GraphicsSettings.defaultRenderPipeline = null;
        }
        else
        {
            GraphicsSettings.defaultRenderPipeline = URP;
        }
    }

    public void aoTrocarValor()
    {
        
        if (this.toggleDalt.isOn)
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
