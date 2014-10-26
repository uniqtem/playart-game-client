using UnityEngine;
using System.Collections;

public class Game2Manager : MonoBehaviour
{	
	private int attackCnt;
	private float startTime =  40.0f; // seconds
	public float timer;
	
	private UILabel playertext;	
	private UILabel scoreText;
	private UILabel missonText;
	private UILabel noukiText;
	
	public bool paused = false;
	public int stagecnt =0;
	
	
	private void reset()
	{
		timer = startTime;
		
		Debug.Log ("@@"+startTime);
	}
	
	void Start ()
	{
		reset();
		
		
		attackCnt = 0;
		playertext =  GameObject.Find("plabel").GetComponent<UILabel>();
		scoreText =  GameObject.Find("score").GetComponent<UILabel>();
		missonText =  GameObject.Find("mlabel").GetComponent<UILabel>();
		noukiText =  GameObject.Find("noukiLabel").GetComponent<UILabel>();
		
		scoreText.text = "進捗"+attackCnt+"%";
		SenceStatic.SENCE = CONFIG.GAME3;
	}
	
	public void ButtonClick (GameObject gO)
	{
		int deltaVal = Random.Range(1, 4);
		scoreText.text = "進捗"+attackCnt +"%";
		stageSelect (deltaVal);
		
		
	}
	
	public void stageSelect(int deltaVal){
		attackCnt += deltaVal;
		
		if (stagecnt == 0) {
			if (0 < attackCnt && attackCnt <= 50) {
				if (deltaVal == 1) {
					missonText.text = "谷原君の髪型って可愛いよねぇ、今回のゲームもこんな感じにできないかなぁ";
					playertext.text = "東田さん邪魔しないで…";
				} else if (deltaVal == 2) {
					missonText.text = "谷原君まだ〜、さっきからずっとまってるんだけど〜";
					playertext.text = "我慢、ここは我慢よ…　";
				} else if (deltaVal == 3) {
					missonText.text = "ほ〜ら、僕の言ったとおりじゃん、さっきまでのキャラとは見違えるほど可愛くなったよ！";
					playertext.text = "…";
				}
			} else if (attackCnt >= 100) {
				playertext.text = "ヒロインの胸とスマイル5割り増しにして、元気で可愛い女の子に仕上げました！";
				stagecnt++;
				attackCnt = 0;
			}
			scoreText.text = "進捗" + attackCnt + "%";
		}
		
		if (stagecnt == 1) {
			if (0 < attackCnt && attackCnt <= 50) {
				if (deltaVal == 1) {
					missonText.text = "ライブラリ作っといたよ、いろんな機能があるから是非使ってみて！";
					playertext.text = "うわー、バグばっかりだ…、見なかったことにしよう…";
				} else if (deltaVal == 2) {
					missonText.text = "どれどれ、プログラムのレビューしてあげるよ、ちょっと見せてみなさい";
					playertext.text = "リリースまで時間がないので、今は完成を優先させてください＞＜";
				} else if (deltaVal == 3) {
					missonText.text = "わしも若い頃はプログラムしたんだがねぇ";
					playertext.text = "大丈夫です、今回は私ががんばります！";				
				}
			} else if (attackCnt >= 100) {
				playertext.text = "先輩の力を借りて、すごくキャラクターが動く派手なバトルを作ることができました！";
				stagecnt++;
				attackCnt = 0;
			}
			scoreText.text = "進捗" + attackCnt + "%";
		}
		
		
		if (stagecnt == 2) {
			if (0 < attackCnt && attackCnt <= 50) {
				if (deltaVal == 1) {
					missonText.text = "この声優さんかわいいよねぇ、いやー是非お仕事頼みたいなー";
					playertext.text = "…、ネットで可愛い声優さんばっかり見てないでお仕事してください(泣)";
				} else if (deltaVal == 2) {
					missonText.text = "戦闘の音楽作ってきたよ、自分が得意のラッパでね「ぷおー」";
					playertext.text = "すごくシュールだ…、ギャグパート作って入れちゃおっと";
				} else if (deltaVal == 3) {
					missonText.text = "ごめん、声優さんのスケジュール押さえるの忘れちゃってたよー";
					playertext.text = "…もうやけくそよ、自分で声をあてちゃうわ！";
				}
			} else if (attackCnt >= 100) {
				playertext.text = "チームのメンバーの力を借りて、コストを下げていい音楽を取り込むことができました";
				stagecnt++;
				attackCnt = 0;
				Application.LoadLevel (CONFIG.SCENARIO);
			}
			scoreText.text = "進捗" + attackCnt + "%";
		}
		
	}
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		Debug.Log (timer);
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			timer = 0.0f;
			paused = true;
		}
		noukiText.text = "納期まで" + System.Math.Floor(timer) + "時間";
	}
	
	/*
	public static double ToRoundDown(double dValue, int iDigits) {
		double dCoef = System.Math.Pow(10, iDigits);
		
		return dValue > 0 ? System.Math.Floor  (dValue * dCoef) / dCoef:
			System.Math.Ceiling(dValue * dCoef) / dCoef;
	}*/
	
}
