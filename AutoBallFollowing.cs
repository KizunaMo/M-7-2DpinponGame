using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBallFollowing : MonoBehaviour
{


    //�۰ʰl�y��
    [SerializeField] private Transform tragetFollow;
    [SerializeField] private float followSpeed = 300f;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AutoFollowBall();
    }

    private void AutoFollowBall()
    {
        //�۰ʰl�y
        float xFollow = tragetFollow.position.x - transform.position.x;
        rb.AddForce(new Vector2(xFollow * followSpeed, 0f), ForceMode2D.Impulse);
    }
}
