using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTreme : MonoBehaviour
{
    public GameObject ShakeFX;
    private float shakeFrequency, shakeAmplitude, shakeTimer;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

     void Update()
    {
        if (shakeTimer > 0)
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeAmplitude;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = shakeFrequency;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
        }
    }

    public void Shake(float duracaoShake, float amplitude, float frequencia){
        shakeTimer = duracaoShake;
        shakeAmplitude = amplitude;
        shakeFrequency = frequencia;
    }

    // public IEnumerator Shake(float tempo){
    //     ShakeFX.SetActive(true);
    //     if(Time.timeScale == 0){
    //         ShakeFX.SetActive(false);
    //     }
    //     yield return new WaitForSeconds(tempo);
    //     ShakeFX.SetActive(false);
    // }
    public void fixCamera(){
        this.transform.localPosition = new Vector3(0, 0, -10);
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
        this.GetComponent<Animator>().SetBool("querFixar", false);
    }
}