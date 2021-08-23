using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRed : MonoBehaviour
{

    [SerializeField] private BallControl ballControlColor;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (!ballControlColor.isRed && !ballControlColor.isBlue && ballControlColor.isGreen)
            {
                Destroy(gameObject);
            }

        }
    }
}
