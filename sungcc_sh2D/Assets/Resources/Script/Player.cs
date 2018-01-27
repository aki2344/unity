using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameObject weapon;
    private GameObject flash;
    private bool isLeft;

	// Use this for initialization
	void Start ()
    {
        weapon = transform.Find("weapon").gameObject;
        flash = weapon.transform.Find("flash").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //iTweenがすでに動いていたら、削除する
            weapon.DestroyITween();

            //マウスの座標を取得
            Vector3 pos = Input.mousePosition;
            //マウスの座標をScene空間上の座標に変換
            pos = Camera.main.ScreenToWorldPoint(pos);

            Vector3 vec = (pos - transform.position).normalized;
            float angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg);
            weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

            flash.GetComponent<Renderer>().enabled = true;

            //スケールを一度縮める
            Vector3 s = weapon.transform.localScale = 
                new Vector3(!isLeft ? -0.14f : 0.14f,0.14f,0.14f);

            //iTweenでアニメーションさせて、スケールを元に戻す
            iTween.ScaleTo(weapon.gameObject, iTween.Hash(
                "scale", s * 1.1f,
                "time", 0.5f,
                "easetype", iTween.EaseType.easeOutElastic));
            StartCoroutine(Finish());
        }
	}
    IEnumerator Finish()
    {
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.02f);
        flash.GetComponent<Renderer>().enabled = false;
    }
}
