using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtivarMobile : MonoBehaviour
{
    private Toggle toggleMobile;

    void Awake()
    {
        this.toggleMobile = this.GetComponent<Toggle>();
        toggleMobile.isOn = PlayerPrefs.GetInt("MobileMode") == 1;
    }
    public void ToggleMobile()
    {
        PlayerPrefs.SetInt("MobileMode", toggleMobile.isOn ? 1 : 0);
    }
}
