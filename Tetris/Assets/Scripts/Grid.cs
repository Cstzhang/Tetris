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
	public static bool InsideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
		(int)pos.x < w &&
		(int)pos.y >= 0);
	}
	//四舍五入位置
	public static Vector2 RoundVec2(Vector2 v) {
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y));
	}

	//检查某一行的每一个元素是否都是满的，有一个为空则不满
	public static bool IsRowFull(int y) {
		for (int x = 0; x < w; x++) {
			if (grid [x, y] == null) {
				return false;
			}
		}
		return true;
	}
	//删除一行
	public static void DeleteRow(int y ) {
        //删除所有数据
        for (int x = 0; x < w;x++ ){
            //删除方块
			Destroy(grid[x, y].gameObject);
            //设置为空
            grid[x, y] = null;

        }

	}
    //删除多行
    public static void DeleteFullRows() {
        for (int y = 0; y < h;){
            if(IsRowFull(y)){
                DeleteRow(y);
                DecreaseRowbove(y+1);
            }else{

                y++;

            }
        }
    }
    //下移动一行
    public static void DescreaseRow(int y){
		//1,移动数据到下一行
		//2,清空改行数据
		//3,视觉上，改变原来的方块的位置（下移一格，y + (-1)）
		for (int x = 0; x < w;x++){
            if(grid[x, y] != null){
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y-1].position += new Vector3(0, -1, 0);

            }
        }
	



	}

    //从指定的行数开始检查，改行和改行以上的位置，上面的位置整体下移一格
    public static void DecreaseRowbove(int y) {
        for (int i = y; i< h; i++){

            DescreaseRow(i);

        }


    }


}
