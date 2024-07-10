using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class cameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int daltonismo;
    private ColorBlindFilter filter;

    [SerializeField] bool tirarURP;
    void Start()
    {
        if (tirarURP)
        {
            GraphicsSettings.defaultRenderPipeline = null;
        }
        daltonismo = PlayerPrefs.GetInt("Daltonismo");
        filter = GetComponent<ColorBlindFilter>();


        switch (daltonismo)
        {
            case 0:
                filter.mode = ColorBlindMode.Normal;
                break;
            case 1:
                filter.mode = ColorBlindMode.Deuteranopia;
                break;
            case 2:
                filter.mode = ColorBlindMode.Protanopia;
                break;
            case 3:
                filter.mode = ColorBlindMode.Tritanopia;
            break;

        }

    }

    public void toggleContraste(Toggle toggle){
        PlayerPrefs.SetInt("AltoContraste", SceneLoaderGame.boolToInt(toggle.isOn));
        print("Altocontraste é " + PlayerPrefs.GetInt("AltoContraste"));
    }
    // Update is called once per frame
    
}
