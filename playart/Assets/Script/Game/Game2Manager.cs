using UnityEngine;
using System.Collections;

public class Game2Manager : MonoBehaviour
{	
	private int attackCnt;

	private UILabel playertext;	
	private UILabel scoreText;
	
	void Start ()
	{
		attackCnt = 0;
		playertext =  GameObject.Find("plabel").GetComponent<UILabel>();
		scoreText =  GameObject.Find("score").GetComponent<UILabel>();
		scoreText.text = "対応状況"+attackCnt;
		SenceStatic.SENCE = CONFIG.GAME3;
	}

	public void ButtonClick (GameObject gO)
	{
		int deltaVal = Random.Range(1, 4);
		attackCnt += deltaVal;
		scoreText.text = "対応状況 "+attackCnt +" %";

		/*
		if(attackCnt == 10) {
			playertext.text = "うわー語彙が足りない！図書館にいくよ！";
		}else if(attackCnt ==30){
			playertext.text = "くじけそう…！";
		}else if(attackCnt ==50){
			playertext.text = "期待の新作年末に発売です！！";
		}else if(attackCnt ==70){
			playertext.text = "楽しくなってきた♪";
		} 
		else if (attackCnt >= 100) {
			Debug.Log ("Break");
			playertext.text = "100人に予約してもらいました！";
		}
		else {
			Debug.Log ("CurrentAtk"+attackCnt);
		}*/

		if(0< attackCnt && attackCnt <= 50) {
			if(deltaVal == 1){
				playertext.text = "うわー いいキャッチコピーが思い浮かばない！図書館にいくよ！";
			}
			else if(deltaVal == 2){
				playertext.text = "東田さんじゃましないでー";
			}
			else if(deltaVal == 3){
				playertext.text = "よし！会心の出来だよ！！";
			}
		}else if(40 < attackCnt && attackCnt <100){
				playertext.text = "うう、くじけそう…";
		} 
		else if (attackCnt >= 100) {
			playertext.text = "コンセプトブラッシュアップして最高のものに仕上げました！！";
			Application.LoadLevel (SenceStatic.SENCE);
		}
		else {
			Debug.Log ("CurrentAtk"+attackCnt);
		}


		//Debug.Log ("Hello");
		//Application.LoadLevel (CONFIG.SCENARIO);
	}


	//キャラクターを隠す
	public void  Hide()
	{
		//renderer.enabled = false;
		//transform.position = new Vector3(1000,1000,1000);
	}
	
}
