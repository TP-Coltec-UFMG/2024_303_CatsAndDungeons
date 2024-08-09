using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System;

public class CameraTreme : MonoBehaviour
{
    public GameObject ShakeFX;
    private float shakeFrequency, shakeAmplitude, shakeTimer;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private bool modoAcessivel;
    void Start(){
    	String cenaAtual = SceneManager.GetActiveScene().name;

        if (cenaAtual.Contains("Acessivel")) {
		    modoAcessivel = true;
        } else {
		    modoAcessivel = false;
        }
    
    }
    
    
    void Update()
    {
    	if(!modoAcessivel){
	    	if (shakeTimer > 0) {
		        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeAmplitude;
		        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = shakeFrequency;
		        shakeTimer -= Time.deltaTime;
		    } else {
		        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
		        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
		    }
    	}
        
    }

    public void Shake(float duracaoShake, float amplitude, float frequencia){
        shakeTimer = duracaoShake;
        shakeAmplitude = amplitude;
        shakeFrequency = frequencia;
    }
}
