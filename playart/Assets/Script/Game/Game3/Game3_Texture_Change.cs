using UnityEngine;
using System.Collections;

public class Game3_Texture_Change : MonoBehaviour {
    UITexture uitexture;

    public Texture2D change_texture;

    GameObject uiroot;

    GameObject panel;

    GameObject texture;

	// Use this for initialization
	void Start () {
        uitexture = GetComponent<UITexture>();

        uiroot = GameObject.Find("UI Root (2D)");

        panel = uiroot.transform.FindChild("Panel:100").gameObject;

        texture = panel.transform.FindChild("Texture").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Texture_Change_flg(float time)
    {

        uitexture.mainTexture = change_texture;
        /*if (time < 5.0f)
        {

        }*/

    }
}
