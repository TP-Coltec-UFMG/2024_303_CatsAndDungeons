using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status{
    gameplay = 0, cinema = 1, inicial = 2,
}
public class StatusJogo : MonoBehaviour {

	public static Status statusAtual = Status.gameplay;

}
