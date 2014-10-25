using UnityEngine;
using System.Collections;

public class ScenarioManager : MonoBehaviour
{
	private string[] stage1 = new string[] {
		"",
		"",
		""
	};

	private string[] stage2 = new string[] {
		"",
		"",
		""
	};

	private string[] stage3 = new string[] {
		"",
		"",
		""
	};

	private UILabel uiLabel;
	private TypewriterEffect typewriterEffect;
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
		StartCoroutine (textAnimation ("test test test" + "\r\n" + "test test test test", 2.5f));
	}

	void Update ()
	{
		if (startFlag) {
			if (Input.GetMouseButtonDown (0) && !inputFlag) {
				inputFlag = true;

				count++;
				if (count == 3) {
					Application.LoadLevel (SenceStatic.SENCE);
				}

				typewriterEffect.Finish ();
				typewriterEffect.ResetToBeginning ();
				StartCoroutine (textAnimation ("nananananananananananananan"));

			}

			if (Input.GetMouseButtonUp (0)) {
				inputFlag = false;
			}
		}
	}

	private IEnumerator SetStart ()
	{
		yield return new WaitForSeconds (2.5f);
		startFlag = true;
	}

	private IEnumerator textAnimation (string text, float time = 0.2f)
	{
		typewriterEffect.Finish ();
		uiLabel.text = text;
		uiLabel.gameObject.SetActive (false);
		yield return new WaitForSeconds (time);

		uiLabel.gameObject.SetActive (true);
		typewriterEffect.ResetToBeginning ();
	}
}
