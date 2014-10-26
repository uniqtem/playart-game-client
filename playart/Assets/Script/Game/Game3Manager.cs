using UnityEngine;
using System.Collections;

public class Game3Manager : MonoBehaviour
{	
	void Start ()
	{
		SenceStatic.SENCE = CONFIG.CLEAR;
	}

	public void ButtonClick (GameObject gO)
	{
		Application.LoadLevel (CONFIG.CLEAR);
	}
}
