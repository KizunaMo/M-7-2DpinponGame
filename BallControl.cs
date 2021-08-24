using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [Header("StatusSetting")]
    public float maxVelocity = 20f;
    public bool _isGreen, _isRed, _isBlue;
    public static bool dead = false;

    [Header("Setting")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ChangeColorRed red;
    [SerializeField] private ChangeColorGreen green;

    public static BallControl ballControl;

    private void Awake()
    {
        if(ballControl == null)
        {
            ballControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("BallGo", 2f);


    }

    private void Update()
    {
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
            Debug.Log("MAX");
        }
    }
    /// <summary>
    /// 用來判斷球在遊戲過程中的狀態
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Red" || collision.collider.tag == "Green")
        {
            int r = Random.Range(0, 4);
            int randomShoot = Random.Range(0, 4);
            float jumpForce = Random.Range(3f, 9f);
            {
                if (r <2  && randomShoot <= 2)
                {
                    //Debug.Log("Left");
                    //Debug.Log(randomShoot);
                    rb.velocity = new Vector2(rb.velocity.x + randomShoot, rb.velocity.y);
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    //Debug.Log("Right");
                    //Debug.Log(randomShoot);
                    rb.velocity = new Vector2(rb.velocity.x - randomShoot, rb.velocity.y);
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
            }
        }
        if (collision.collider.tag == "Red" )
        {
            gameManager.ScoreCount();// +1分
            if (red.isRed)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);//red
                _isRed = true;
                _isGreen = false;
                _isBlue = false;
            }
            else if (red.isGreen)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
                _isRed = false;
                _isGreen = true;
                _isBlue = false;
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//BallColor
                _isRed = false;
                _isGreen = false;
                _isBlue = true;
            }
        }

        if (collision.collider.tag == "Green")
        {
            gameManager.ScoreCount();// +1分
            if (green.isRed)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);
                _isRed = true;
                _isGreen = false;
                _isBlue = false;
            }
            else if (green.isGreen)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
                _isRed = false;
                _isGreen = true;
                _isBlue = false;
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//BallColor
                _isRed = false;
                _isGreen = false;
                _isBlue = true;
            }
        }

        if(collision.gameObject.tag == "Player01")
        {
            AudioManager.instance.Play("Catch");
        }
       
    }


    void BallGo()
    {
        float randonUnmber = Random.Range(0, 2);
        if (randonUnmber <= 0.5f)
        {
            rb.AddForce(new Vector2(3f, -60f));
            //Debug.Log("Shoot right");
        }
        else
        {
            rb.AddForce(new Vector2(3f, -60f));
            //Debug.Log("Shoot left");
        }
    }

    /// <summary>
    /// 用來判斷是有結束遊戲
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollider(collision.gameObject);
    }

    public void ProcessCollider(GameObject collider)
    {
        if (collider.gameObject.CompareTag("Dead"))
        {
            AudioManager.instance.Play("Fail");
            rb.transform.position = new Vector3(0f, 2f, 0f);
            rb.velocity = new Vector2(0f, 0f);
            dead = true;
        }
        
    }

}



