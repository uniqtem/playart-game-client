using UnityEngine;
using System.Collections;

public class ScenarioManager : MonoBehaviour
{


	// component
	private UILabel uiLabel;
	private UISprite uiSpriteMan;
	private UISprite uiSpriteWoman;
	private UISprite uiSpriteWoman2;
	private TypewriterEffect typewriterEffect;
	// value
	private int count;
	private bool startFlag;
	private bool inputFlag;

	void Start ()
	{
		count = 0;
		GameObject gObj = GameObject.Find ("Text");
		uiLabel = gObj.GetComponent<UILabel> ();
		typewriterEffect = gObj.GetComponent<TypewriterEffect> ();

		startFlag = false;
		inputFlag = false;
		StartCoroutine (SetStart ());
		Text (2.5f);

		uiSpriteMan = GameObject.Find ("Character2").GetComponent<UISprite> ();
		uiSpriteWoman = GameObject.Find ("Character1").GetComponent<UISprite> ();
		uiSpriteWoman2 = GameObject.Find ("Character3").GetComponent<UISprite> ();

		Face ();
//		StartCoroutine (textAnimation ("test test test" + "\r\n" + "test test test test", 2.5f));
	}

	void Update ()
	{
		if (startFlag) {
			if (Input.GetMouseButtonDown (0) && !inputFlag) {
				inputFlag = true;

				count++;
				if (count >= Stage ().Length) {
					Application.LoadLevel (SenceStatic.SENCE);
				}


				Face ();

				Text ();
			}

			if (Input.GetMouseButtonUp (0)) {
				inputFlag = false;
			}
		}
	}

	private void Face ()
	{
		string tempMan = DATA.stage1_man[count];
		string tempWoman = DATA.stage1_woman[count];
		string tempWoman2 = DATA.stage1_woman2[count];

		switch (SenceStatic.SENCE) {
		case CONFIG.GAME2 :
			tempMan = DATA.stage2_man[count];
			tempWoman = DATA.stage2_woman[count];
			tempWoman2 = DATA.stage2_woman2[count];
			break;
		case CONFIG.GAME3 :
			tempMan = DATA.stage3_man[count];
			tempWoman = DATA.stage3_woman[count];
			tempWoman2 = DATA.stage3_woman2[count];
			break;
		}
	
		uiSpriteMan.spriteName = tempMan;
		uiSpriteWoman.spriteName = tempWoman;
		uiSpriteWoman2.spriteName = tempWoman2;
	}

	private string[] Stage ()
	{
		string[] temp = DATA.STAGE1;
		switch (SenceStatic.SENCE) {
		case CONFIG.GAME2 :
			temp = DATA.STAGE2;
			break;
		case CONFIG.GAME3 :
			temp = DATA.STAGE3;
			break;
		}

		return temp;
	}

	private void Text (float time = 0.2f)
	{
		string[] temp = Stage ();
		StartCoroutine (textAnimation (temp[count], time));
	}

	private IEnumerator SetStart ()
	{
		yield return new WaitForSeconds (2.5f);
		startFlag = true;
	}

	private IEnumerator textAnimation (string text, float time)
	{
		typewriterEffect.Finish ();
		uiLabel.text = text;
		uiLabel.gameObject.SetActive (false);
		yield return new WaitForSeconds (time);

		uiLabel.gameObject.SetActive (true);
		typewriterEffect.ResetToBeginning ();
	}
}
