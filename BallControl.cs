using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxVelocity = 20f;
    private SpriteRenderer spriteRenderer;

    public ChangeColor red;
    public ChangeColor green;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("BallGo", 2f);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player01")
        {
            int r = Random.Range(0, 4);
            int randomShoot = Random.Range(0, 9);
            float jumpForce = Random.Range(1f, 12f);
            {
                if (r < 2 && randomShoot<=4)
                {

                    Debug.Log("Left");
                    Debug.Log(randomShoot);
                    rb.velocity = new Vector2(rb.velocity.x + randomShoot, rb.velocity.y);
                    rb.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                }
                else
                {
                    Debug.Log("Right");
                    Debug.Log(randomShoot);
                    rb.velocity = new Vector2(rb.velocity.x - randomShoot, rb.velocity.y);
                }

                if (rb.velocity.magnitude > maxVelocity)
                {
                    rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
                    Debug.Log("MAX");
                }
            }
        }

        if(collision.collider.tag == "Red")
        {
            if (red.isRed)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);
            }
            else if (red.isGreen)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//BallColor
            }
        }

        if (collision.collider.tag == "Green")
        {
            if (green.isRed)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);
            }
            else if (green.isGreen)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//BallColor
            }
        }
           

    }



    void BallGo()
    {
        float randonUnmber = Random.Range(0, 2);
        if (randonUnmber <= 0.5f)
        {
            rb.AddForce(new Vector2(3f, -60f));
            Debug.Log("Shoot right");
        }
        else
        {
            rb.AddForce(new Vector2(3f, -60f));
            Debug.Log("Shoot left");
        }
    }

    void ResetBall()
    {

    }


}



