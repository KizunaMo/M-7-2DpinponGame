using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isGreen, isRed, isBallColor;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int changeColor = Random.Range(0, 9);

        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Ctach");
            if (changeColor <= 3)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);//Red
                isRed = true;
                isGreen = false;
                isBallColor = false;
            }
            else if(changeColor >3 && changeColor <7)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
                isRed = false;
                isGreen = true;
                isBallColor = false;
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//BallColor
                isRed = false;
                isGreen = false;
                isBallColor = true;
            }
        }

    }
   
           
    

}
