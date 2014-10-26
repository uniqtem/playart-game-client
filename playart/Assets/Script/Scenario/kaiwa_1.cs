using UnityEngine;
using System.Collections;

public class kaiwa_1 : MonoBehaviour {
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
        StartCoroutine(textAnimation("谷原:" + "\r\n" + "はじめまして、谷原けいこです" + "\r\n" + "今日からよろしくお願いします", 2.5f));

    }

    void Update()
    {
        if (startFlag)
        {
            if (Input.GetMouseButtonDown(0) && !inputFlag)
            {
                inputFlag = true;

                count++;
                if (count >= 23)
                {
                    Application.LoadLevel(SenceStatic.SENCE);
                }

                typewriterEffect.Finish();
                typewriterEffect.ResetToBeginning();
                //StartCoroutine(textAnimation("nananananananananananananan"));
                //if(count == 0)
                //StartCoroutine(textAnimation("谷原:" + "\r\n" + "はじめまして、谷原けいこです" + "\r\n"+"今日からよろしくお願いします"));
                if(count == 1)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "おおっ！若いねぇ!!! "+"\r\n"+"元気いいねー、いやー うちの年増とは違うねぇ！"));

                if(count == 2)
                StartCoroutine(textAnimation("木田:" + "\r\n" +"誰のことかしら？答え次第ではぶん殴るわよ?"+"\r\n"
                                                +"…彼の名前は東田よ" + "\r\n"+"ゲーム制作20年のベテランよ"+"\r\n"+"何本かヒット作も出しているわ"));
                if(count == 3)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "ガハハ！　わしに任せておけば問題ない!" + "\r\n"+"なんといっても経験が違うからね、経験が"));
                if(count == 4)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "…ちょっと暑苦しくて、不細工で、年食っていて"+"\r\n"+"臭くて、頭が悪くて、センスもないけど"+"\r\n"
                                                    +"悪いやつじゃないから仲良くしてあげてね"));
                if(count == 5)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "ひどいなぁ木田ちゃん、そんなんだからシワが増えるんだよ"));

                if(count == 6)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "…さてと、うちは小さなゲーム開発チームだから"+"\r\n"+"すぐに実務に入ってもらうわ"));

                if(count == 7)
                StartCoroutine(textAnimation("谷原:" + "\r\n" + "えっ、もう私がゲーム開発に関わっていいんですか？"));

                if(count == 8)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "もちろんよ、谷原さんの能力の高さは、面接時に見せてもらった企画書や"+"\r\n"+"プレゼン能力で十分に理解できたわ"));

                if(count == 9)
                StartCoroutine(textAnimation("谷原:" + "\r\n" + "えへへ"));

                if(count == 10)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "では、まずゲーム制作で最初にやらなければいけないことについて"+"\r\n"+"それはコンセプトを決めることよ"));

                if(count == 11)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "コンセプトぉ？そんなもんパクればいいんじゃないかねぇ"));

                if(count == 12)
                StartCoroutine(textAnimation("谷原:" + "\r\n" + "ええっ！そうなんですか先輩"));

                if(count == 13)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "もー、東田くんは何も考えなさすぎよ、他のゲームのいい所を参考にするのは重要だけど"+"\r\n"+"そればっかりやっていると、新しいゲームが出るたびに方針変更が入って"
                                                +"\r\n"+"全然ゲームが完成しなくなるわ"));

                if(count == 14)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "だから、ゲームにおいて一番重用な事をきめて"+"\r\n"+"それをベースにして必要・不必要を見分けなきゃいけないの"));

                if(count == 15)
                StartCoroutine(textAnimation("谷原:" + "\r\n" + "なるほど〜わかりました！"));

                if(count == 16)
                StartCoroutine(textAnimation("木田:" + "\r\n"+"では、これからゲームのコンセプトを作り上げっていってもらうわ"+"\r\n"
                                                + "ゲームのコンセプトは東田くんから引き出して、作り上げてみて"));

                if(count == 17)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "大変だと思うけど、彼はこう見えても" + "\r\n" +"累計売上30万本のゲームを作ったことのあるベテランなの"));

                if(count == 18)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "…認めたくないけど"));

                if(count == 19)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "ふふふ、私に任しておけば問題はない"));

                if(count == 20)
                StartCoroutine(textAnimation("木田:" + "\r\n" + "はいはい"+"\r\n"+"彼のセンスももうかなり古くて錆び付いているから"+"\r\n"+"最近の流行を知っていてしっかり者のあなたが、上手くフォローしてあげて"));

                if(count == 21)
                StartCoroutine(textAnimation("東田:" + "\r\n" + "木田ちゃんそれはひど…"));

                if(count == 22)
                StartCoroutine(textAnimation("谷原:" + "\r\n" + "はい、わかりました！"));
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
        Debug.Log("test");
        typewriterEffect.Finish();
        uiLabel.text = text;
        uiLabel.gameObject.SetActive(false);
        yield return new WaitForSeconds(time);

        uiLabel.gameObject.SetActive(true);
        typewriterEffect.ResetToBeginning();
    }
}
