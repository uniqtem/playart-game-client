using UnityEngine;
using System.Collections;

public class Game3_Scene_Change : MonoBehaviour {

    public string scene_name_good;
    public string scene_name_bad;

	// Use this for initialization
	void Start () {
	
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
        Application.LoadLevel(scene_name_bad);
    }
}
