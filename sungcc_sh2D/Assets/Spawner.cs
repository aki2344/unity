using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obj;
    public Transform top;
    public Transform bottom;
    public float rate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)
            return;
        if (Random.value < rate)
        {
            Vector3 pos;
            pos.x = Mathf.Lerp(top.position.x, bottom.position.x, Random.value);
            pos.y = Mathf.Lerp(top.position.y, bottom.position.y, Random.value);
            pos.z = Mathf.Lerp(top.position.z, bottom.position.z, Random.value);
            Instantiate(obj, pos, Quaternion.identity);
        }
    }
}
