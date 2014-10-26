using UnityEngine;
using System.Collections;

public class LoginManager : MonoBehaviour
{
	public void StartButton ()
	{
		Application.LoadLevel (CONFIG.SCENARIO);
	}
}
