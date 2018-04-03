using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MonoBehaviour {

    public Vector2 v;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(v * Time.deltaTime);
    }
}
