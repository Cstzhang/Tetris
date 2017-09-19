using UnityEngine;
using System.Collections;

public class GroupsManager : MonoBehaviour {
	float lastFallTime = 0;
	// Use this for initialization
	void Start () {
		//判断当前还有没有容量 没有则游戏结束
		if(!IsValidGridPos()){
			Debug.Log ("GAME OVER");
            //show gameover UI
            //GameObject bg =  GameObject.Find("Canvas/Background");
            GameObject.Find("Canvas").GetComponent<GUIManager>().GameOver();
            //delete
			Destroy (gameObject);
		}
	
		
	}
	
	// Update is called once per frame
	void Update () {
	  //1，控制方块 左移动
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			//移动一格
			transform.position += new Vector3 (-1, 0, 0);
			if (IsValidGridPos()) {
				UpdateGrid ();
			} else {//还原
				transform.position += new Vector3 (1, 0, 0); 
			
			}

				
		}
	  //2，控制方块 右移动
	     else if(Input.GetKeyDown(KeyCode.RightArrow)){
			//移动一格
			transform.position += new Vector3 (1, 0, 0); 
			if (IsValidGridPos()) {
				UpdateGrid ();

			} else {//还原
				transform.position += new Vector3 (-1, 0, 0); 

			}
		}

	  //3，控制方块 旋转
		else if(Input.GetKeyDown(KeyCode.UpArrow)){
			//选择
			transform.Rotate (0, 0, -90);
			if (IsValidGridPos()) {
                UpdateGrid ();

			} else {//还原
				transform.Rotate (0, 0, 90);

			}
		}
	  //4，控制方块 快速掉落 按下键或者每秒自动下移
		else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFallTime >= 1){
			//移动一格
			transform.position += new Vector3 (0, -1, 0); 
			if (IsValidGridPos()) {
				UpdateGrid ();

			} else {//还原
				transform.position += new Vector3 (0, 1, 0);
                //已经到底，调用判断是否满足删除下一行
                Grid.DeleteFullRows();

				//调用下一个
				FindObjectOfType<Spawner> ().SpawnNext ();

				//让当前的脚本失效
				enabled = false;

			}
			lastFallTime = Time.time;
		}

	}

	//是否有效，还有存放空间
	bool IsValidGridPos() {
		foreach (Transform child in transform) {
			Vector2 v = Grid.RoundVec2 (child.position);
			//1,判断是否在边界之内 左右下
			if (!Grid.InsideBorder (v)) {
				return false;
			}
			//2,判断现在的grid对应的格子是null 为空才能放下放方块
			if(Grid.grid[(int)v.x,(int)v.y]!=null && Grid.grid[(int)v.x,(int)v.y].parent != transform) {
				return false;
			}

		}
		return true;
	}


	//更新格子所占位置
	void UpdateGrid() {
		//改变原来的位置，删除上一个位置的数据
		for(int y=0;y<Grid.h;y++){
			for(int x=0;x<Grid.w;x++){
				if (Grid.grid [x, y] != null && Grid.grid [x, y].parent == transform) {
					Grid.grid [x, y] = null;
				}

			}
		}
		//加入本次的位置信息
		foreach (Transform child in transform) {
			Vector2 v = Grid.RoundVec2 (child.position);
			//插入数组
			Grid.grid [(int)v.x, (int)v.y] = child;
		}

	}





}
