using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorblindFilters : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private new CameraController camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraController>();
    }

    public void mudaDaltonismo()
    {
        PlayerPrefs.SetInt("Daltonismo", dropdown.value+1);
        switch (dropdown.value+1)
        {
            case 1:
                camera.filter.mode = ColorBlindMode.Deuteranopia;
                break;
            case 2:
                camera.filter.mode = ColorBlindMode.Protanopia;
                break;
            case 3:
                camera.filter.mode = ColorBlindMode.Tritanopia;
                break;

        }
    }
}