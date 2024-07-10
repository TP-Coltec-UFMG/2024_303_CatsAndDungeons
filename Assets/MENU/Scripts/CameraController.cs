using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public ColorBlindFilter filter;

    // Start is called before the first frame update
    void Start(){
        filter = GetComponent<ColorBlindFilter>();
    }
}
