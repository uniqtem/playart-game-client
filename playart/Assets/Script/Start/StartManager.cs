using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour
{
	private QueryAnimationController anim;
	private QuerySoundController sound;

	void Start ()
	{
		GameObject gObj = GameObject.Find ("Query-Chan");
		anim = gObj.GetComponent<QueryAnimationController> ();
		sound = gObj.GetComponent<QuerySoundController> ();

		Play ();

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Play ();
		}
	}

	private void Play ()
	{
		anim.ChangeAnimation (GetRandomEnum<QueryAnimationController.QueryChanAnimationType> ());
		sound.PlaySoundByType (GetRandomEnum<QuerySoundController.QueryChanSoundType> ());
	}

	private T GetRandomEnum<T> ()
	{
		System.Array A = System.Enum.GetValues (typeof(T));
		T V = (T)A.GetValue (UnityEngine.Random.Range (0,A.Length));
		return V;
	}

	public void StartButton ()
	{
		Application.LoadLevel (CONFIG.SCENARIO);	
	}
}
