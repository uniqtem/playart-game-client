using UnityEngine;
using System.Collections;

public class Game3_Error : MonoBehaviour {

    GameObject uiroot;

    GameObject error;

    GameObject panel;

	// Use this for initialization
	void Start () {

        uiroot = GameObject.Find("UI Root (2D)");

        panel = uiroot.transform.FindChild("Panel:100").gameObject;

        error = panel.transform.FindChild("Error").gameObject;

        Initialize();
	
	}

    void Initialize()
    {
        error.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public IEnumerator Error_flg()
    {
        error.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Initialize();
    }
}
