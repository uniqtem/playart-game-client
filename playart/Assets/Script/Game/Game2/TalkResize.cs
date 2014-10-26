using UnityEngine;
using System.Collections;

public class TalkResize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public void  OnMouseDown () {

	}

	public void ButtonClick (GameObject gO)
	{

	}

	public void Update(){

		transform.localScale =  new Vector3( Mathf.Sin( Time.time * 2) + 2, 1 , 1 );
	}
}
