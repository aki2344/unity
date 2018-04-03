using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject HitParticle;

    // Use this for initialization
    void Start()
    {
        HitParticle = Resources.Load<GameObject>("Prefab/HitParticle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("click");
        Instantiate(HitParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
