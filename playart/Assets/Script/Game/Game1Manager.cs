using UnityEngine;
using System.Collections;

public class Game1Manager : MonoBehaviour
{
	void Start ()
	{
		SenceStatic.SENCE = CONFIG.GAME2;
	}

	public void ButtonOnClick (GameObject gO)
	{
		Application.LoadLevel (CONFIG.SCENARIO);
	}
}
