using UnityEngine;
using System.Collections;

public class GroupsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  //1，控制方块 左移动
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.position += new Vector3 (-1, 0, 0); 
		}
	  //2，控制方块 右移动
	     else if(Input.GetKeyDown(KeyCode.RightArrow)){

			transform.position += new Vector3 (1, 0, 0); 

		}
	  //3，控制方块 旋转
		else if(Input.GetKeyDown(KeyCode.UpArrow)){

			transform.Rotate (0, 0, -90);

		}
	  //4，控制方块 快速掉落
		else if(Input.GetKeyDown(KeyCode.DownArrow)){

			transform.position += new Vector3 (0, -1, 0); 

		}
	}

}
