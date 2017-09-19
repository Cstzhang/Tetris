using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public static int w = 10;
	public static int h = 20;
	//二维数组，记录当前游戏窗口的方块情况
	public static Transform[,] grid = new Transform[w, h];
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
	
	}
	//是否超出 保障每个检查的位置不小于左边框 不大于右边框 不小于最小的Y
	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
		(int)pos.x < w &&
		(int)pos.y >= 0);
	}
	//四舍五入位置
	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
	}
}
