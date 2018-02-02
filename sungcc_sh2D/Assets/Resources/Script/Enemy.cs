using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のクラス
/// </summary>
public class Enemy : MonoBehaviour {
    /// <summary>
    /// クリックしたときのパーティクル
    /// </summary>
    public GameObject HitParticle;
    /// <summary>
    /// 敵を倒したときのパーティクル
    /// </summary>
    public GameObject BombParticle;
    /// <summary>
    /// ライフ
    /// </summary>
    public float life;
    /// <summary>
    /// 初期サイズ
    /// </summary>
    private Vector3 initialScale;
    /// <summary>
    /// 加算ポイント
    /// </summary>
    public int point;

	void Start ()
    {
        //パーティクルの参照が渡されていなかったら、Resourcesから参照を取得
        if (HitParticle == null)
            HitParticle = Resources.Load<GameObject>("Prefab/HitParticle");
        if (BombParticle == null)
            BombParticle = Resources.Load<GameObject>("Prefab/BombParticle");
        //初期サイズを取得
        initialScale = transform.localScale;
	}
	
	void Update () {
		
	}
    /// <summary>
    /// マウスでクリックされた時の処理
    /// </summary>
    void OnMouseDown()
    {
        life -= 1;

        //ライフがまだ残っているとき
        if (life > 0)
        {
            //マウスの座標にパーティクルを生成
            //マウスの座標を取得
            Vector3 pos = Input.mousePosition;
            //マウスの座標をScene空間上の座標に変換
            pos = Camera.main.ScreenToWorldPoint(pos);
            //パーティクルの生成
            if (HitParticle != null)
                Destroy(Instantiate(HitParticle, pos, transform.rotation), 3);

            //iTweenがすでに動いていたら、削除する
            gameObject.DestroyITween();
            Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                //iTweenがすでに動いていたら、削除する
                r.gameObject.DestroyITween();
                //色を一度赤に染める
                r.material.color = Color.red;
                //iTweenでアニメーションさせて、色を元に戻す
                iTween.ColorTo(r.gameObject, iTween.Hash(
                    "color", Color.white,
                    "time", 0.2f));
            }
            //スケールを一度縮める
            transform.localScale *= 0.9f;
            //iTweenでアニメーションさせて、スケールを元に戻す
            iTween.ScaleTo(gameObject, iTween.Hash(
                "scale", initialScale,
                "time", 0.5f,
                "easetype", iTween.EaseType.easeOutElastic));
            
            //スコアの加算
            Score.instance.Add(10);
        }
        else
        {
            //敵のライフが0になったとき
            Score.instance.Add(point);
            if (BombParticle != null)
                Destroy(Instantiate(BombParticle, transform.position, transform.rotation) as GameObject, 8);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 画面から見切れて見えなくなった時
    /// </summary>
    void OnBecameInvisible()
    {
        //敵のオブジェクトを削除
        Destroy(gameObject);
    }
}
