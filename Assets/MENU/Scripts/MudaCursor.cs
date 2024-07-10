using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    [SerializeField] private Texture2D texturaIdle, texturaTouch;
    Vector2 cursorHotspot;
    void Start(){
        cursorHotspot = new Vector2(texturaIdle.width/2, texturaIdle.height/2);
        Cursor.SetCursor(texturaIdle, cursorHotspot, CursorMode.ForceSoftware); 
    }
    void Update(){
         if(Input.GetMouseButtonDown(0)){
            Cursor.SetCursor(texturaTouch, cursorHotspot, CursorMode.ForceSoftware); 
         }
         if(Input.GetMouseButtonUp(0)){
            Cursor.SetCursor(texturaIdle, cursorHotspot, CursorMode.ForceSoftware); 
         }
    }
}