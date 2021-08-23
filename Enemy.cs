using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Transform tragetFollow;
    [SerializeField] private float followSpeed = 300f;
    [SerializeField] private float yPosition;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector2(rb.position.x, yPosition);
    }

    // Update is called once per frame
    void Update()
    {
            float xFollow = tragetFollow.position.x - transform.position.x;
            rb.AddForce(new Vector2(xFollow * followSpeed, 0f), ForceMode2D.Impulse);
    }

  
    

}
