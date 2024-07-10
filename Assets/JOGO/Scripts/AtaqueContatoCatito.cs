using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueContatoCatito : MonoBehaviour
{
    private InimigoMorte inimigo;

    private void OnTriggerEnter2D(Collider2D collider){

        if (collider.name == "InimigoOBJ")
        {
            inimigo = collider.GetComponent<InimigoMorte>();
            inimigo.Morrer();
        }
    }
}
