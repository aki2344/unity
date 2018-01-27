using UnityEngine;
using System.Collections;

/*
 * スコアを管理するクラス
 */ 
public class Score : MonoBehaviour {

	// Score クラス唯一のインスタンス
	private static Score mInstance;

	/*
	 * Score インスタンスを返す関数
	 * (static で public なので、どのソースコードからも呼ぶことができる)
	 */
	public static Score instance {
		get{
			// インスタンスが参照されているか
			if (mInstance == null) {
				// インスタンスを探し、参照する
				mInstance = FindObjectOfType<Score> ();
			}
			// インスタンスを返す
			return mInstance;
		}
	}

	void Start () {
		// インスタンスがこれ自身でなければ消す
		if (this != instance) {
			Destroy (this);
		}
	}

	public int score {
		get;
		// set はこのソースコードからしか呼ばれないようにする
		private set;
	}

	/*
	 * スコアに1を足す関数
	 */
	public void Add(int point){
		score += point;
	}

	/* 
	 * スコアを0にする関数
	 */
	public void Reset(){
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
