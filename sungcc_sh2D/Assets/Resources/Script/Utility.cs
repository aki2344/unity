using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {

	public static void DestroyITween(this GameObject g)
    {
        //iTweenがすでに動いていたら、削除する
        iTween tw;
        if ((tw = g.GetComponent<iTween>()) != null)
        {
            Object.DestroyImmediate(tw);
        }
    }
}
