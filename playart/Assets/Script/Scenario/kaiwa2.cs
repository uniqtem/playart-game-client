using UnityEngine;
using System.Collections;

public class kaiwa1 : MonoBehaviour {
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

    void Start()
    {
        count = 0;
        GameObject gObj = GameObject.Find("Text");
        uiLabel = gObj.GetComponent<UILabel>();
        typewriterEffect = gObj.GetComponent<TypewriterEffect>();

        startFlag = false;
        inputFlag = false;
        StartCoroutine(SetStart());
        //StartCoroutine(textAnimation("test test test" + "\r\n" + "test test test test", 2.5f));
        StartCoroutine(textAnimation("谷原:" + "\r\n" + "ぜーはー、ぜーはー" + "\r\n" + "頭フル回転で疲れました…", 2.5f));

    }

    void Update()
    {
        if (startFlag)
        {
            if (Input.GetMouseButtonDown(0) && !inputFlag)
            {
                inputFlag = true;

                count++;
                if (count == 7)
                {
                    Application.LoadLevel(SenceStatic.SENCE);
                }

                typewriterEffect.Finish();
                typewriterEffect.ResetToBeginning();
                //StartCoroutine(textAnimation("nananananananananananananan"));
                //if(count == 0)
                //StartCoroutine(textAnimation("谷原:" + "\r\n" + "はじめまして、谷原けいこです" + "\r\n"+"今日からよろしくお願いします"));
                if (count == 1)
                    StartCoroutine(textAnimation("木田:" + "\r\n" + "お疲れ様、大変な仕事をよくこなしたわ。" + "\r\n" + "ゲーム制作において粘り強くコミュニケーションを取ることは一番重用なスキルよ"));

                if (count == 2)
                    StartCoroutine(textAnimation("東田:" + "\r\n" + "そうだな、わしのように、誰とでもロジカルな会話をできるようになれるように目指すんだぞ"));
                if (count == 3)
                    StartCoroutine(textAnimation("谷原:" + "\r\n" + "…………………"));
                if (count == 4)
                    StartCoroutine(textAnimation("木田:" + "\r\n" + "はい、気をとり直して次は実際のゲーム開発よ" + "\r\n" + "ゲーム開発で重要なのは気合よ！"));
                if (count == 5)
                    StartCoroutine(textAnimation("木田:" + "\r\n" + "やっていることに迷ったり、シナリオが支離滅裂になることもあるかもしれないけど" + "\r\n" + "あなたの「ゲームを完成させたい」っていう情熱があれば、すべて解決できるわ"+ "\r\n"+"次々に迫ってくる難題を、あなたの情熱で跳ね返して、ゲームを完成させて！"));
                if (count == 6)
                    StartCoroutine(textAnimation("木田:" + "\r\n" + "…さてと、うちは小さなゲーム開発チームだから" + "\r\n" + "すぐに実務に入ってもらうわ"));
            }

            if (Input.GetMouseButtonUp(0))
            {
                inputFlag = false;
            }
        }
    }

    private IEnumerator SetStart()
    {
        yield return new WaitForSeconds(2.5f);
        startFlag = true;
    }

    private IEnumerator textAnimation(string text, float time = 0.2f)
    {
        //Debug.Log("test");
        typewriterEffect.Finish();
        uiLabel.text = text;
        uiLabel.gameObject.SetActive(false);
        yield return new WaitForSeconds(time);

        uiLabel.gameObject.SetActive(true);
        typewriterEffect.ResetToBeginning();
    }
}
