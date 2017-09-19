using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	float gameTime,startTime;
	Text timeText,scoreText;
    public GameObject GameOverUI;
    bool isEnd = false;
	// Use this for initialization
	void Start () {
		//计时器
		timeText = GameObject.Find("Canvas/Timer").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
		//得到游戏开始时间 s
		startTime = Time.time;
        scoreText.text = 0.ToString();
	}


	// Update is called once per frame
	void Update () {
        if(isEnd){
            return;
        }
	   //游戏时间 s
		gameTime = Time.time - startTime;
	   // s
		int seconds = (int)(gameTime % 60); 
	   // m
		int minutes = (int)(gameTime / 60 );
		// time string  Format
		string strTime = string.Format("{0:00}:{1:00}",minutes,seconds);

		timeText.text = strTime;
	}

    //结束游戏
    public void GameOver() {
        GameOverUI.SetActive(true);
        isEnd = true;
    }

    public void scoreAdd(){

        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();

    }

}
