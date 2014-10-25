using UnityEngine;
using System.Collections;

public class ClearManager : MonoBehaviour
{
	void Start ()
	{
		SenceStatic.SENCE = CONFIG.GAME1;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel (CONFIG.START);
		}
	}
}
