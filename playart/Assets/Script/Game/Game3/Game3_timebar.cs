using UnityEngine;
using System.Collections;

public class Game3_timebar : MonoBehaviour {

    UISlider uislider;

    public string scene_name;

    public float time;

    GameObject uiroot;

    GameObject panel;

    GameObject texture;

    Game3_Texture_Change game3_texture_change;

	// Use this for initialization
	void Start () {

        uislider = GameObject.Find("Slider").GetComponent<UISlider>();

        uiroot = GameObject.Find("UI Root (2D)");

        panel = uiroot.transform.FindChild("Panel:100").gameObject;

        texture = panel.transform.FindChild("Texture").gameObject;

        game3_texture_change = texture.GetComponent<Game3_Texture_Change>();

        uislider.value = 1.0f;

	}
	
	// Update is called once per frame
	void Update () {

        uislider.value -= Time.deltaTime/time;

        if (uislider.value <= 0)
        {

            Application.LoadLevel(scene_name);

        }

        if (uislider.value <= .5f)
        {

            game3_texture_change.Texture_Change_flg(uislider.value);

        }

	}
}
