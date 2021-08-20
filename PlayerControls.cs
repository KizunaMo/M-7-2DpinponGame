using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public KeyCode moveLeft;
    public KeyCode moveRight;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            rb.velocity = new Vector2 (moveSpeed * -1f * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(moveRight))
        {
            rb.velocity = new Vector2 (moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

    }

}
