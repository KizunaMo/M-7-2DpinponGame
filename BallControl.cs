using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxVelocity = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("BallGo", 2f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
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



