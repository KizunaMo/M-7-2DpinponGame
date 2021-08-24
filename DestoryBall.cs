using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBall : MonoBehaviour
{
    private Collider2D coll;
    public GameObject ball;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

   
}
