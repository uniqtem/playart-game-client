using UnityEngine;
using System.Collections;

public class Game3_Scene_Change : MonoBehaviour {

    public string scene_name_good;

    public string scene_name_bad;

    GameObject uiroot;

    GameObject error;

    GameObject panel;

    Game3_Error game3_error;

	// Use this for initialization
	void Start () {

        uiroot = GameObject.Find("UI Root (2D)");

        panel = uiroot.transform.FindChild("Panel:100").gameObject;

        error = panel.transform.FindChild("Error").gameObject;

        game3_error = error.GetComponent<Game3_Error>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonClick_Good()
    {
        Application.LoadLevel(scene_name_good);
    }

    public void ButtonClick_Bad()
    {
        StartCoroutine(game3_error.Error_flg());
    }
}
