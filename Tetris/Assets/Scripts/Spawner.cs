using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	//产生随机数，实例化模型
	public GameObject[] groups;

	// Use this for initialization
	void Start () {
		SpawnNext ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	//生成
	public void SpawnNext() {
		int i = Random.Range (0, groups.Length);
		GameObject ins = Instantiate (groups [i], transform.position, Quaternion.identity) as GameObject;




	}


}
