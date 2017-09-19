using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	float gameTime,startTime;
	Text timer;

	// Use this for initialization
	void Start () {
		//计时器
		timer = GameObject.Find("Canvas/Timer").GetComponent<Text>();
		//得到游戏开始时间 s
		startTime = Time.time;

	}


	// Update is called once per frame
	void Update () {
	   //游戏时间 s
		gameTime = Time.time - startTime;
	   // s
		int seconds = (int)(gameTime % 60); 
	   // m
		int minutes = (int)(gameTime / 60 );
		// time string  Format
		string strTime = string.Format("{0:00}:{1:00}",minutes,seconds);

		timer.text = strTime;
	}




}
