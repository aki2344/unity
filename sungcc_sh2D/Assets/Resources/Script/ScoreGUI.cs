using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreGUI : MonoBehaviour {

	private Text mText;
    private int preScore;

	void Start () {
		mText = GetComponent<Text> ();
        preScore = Score.instance.score;
    }
	
	void Update () {
		// Score クラスから score を得る
		int score = Score.instance.score;
		// 3桁になるように0を足す
		string scoreAddZero = score.ToString ("000000");
		// テキストをGUIで表示する
		mText.text = "Score:" + scoreAddZero;
        //直前のスコアと比較して、変化していたらアニメーションする
        if (preScore != score)
        {
            //iTweenがすでに動いていたら削除する
            gameObject.DestroyITween();
            //Y方向のスケールを一度縮める
            Vector3 s =transform.localScale;
            s.y = 0.5f;
            transform.localScale = s;
            //iTweenでアニメーションさせて、スケールを元に戻す
            iTween.ScaleTo(gameObject, iTween.Hash(
                "scale", Vector3.one,
                "time", 0.5f,
                "easetype", iTween.EaseType.easeOutElastic));
        }
        //直前のスコアを更新
        preScore = score;
	}
}
