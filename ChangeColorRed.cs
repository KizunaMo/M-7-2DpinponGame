using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRed: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isGreen, isRed, isBlue;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRed = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int changeColor = Random.Range(0, 9);//0~8

        if (collision.gameObject.tag == "Ball")
        {
            //Debug.Log("Ctach");
            if (changeColor <= 2)
            {
                spriteRenderer.color = new Color(1f, 0.19f, 0f, 1f);//Red
                isRed = true;
                isGreen = false;
                isBlue = false;
            }
            else if(changeColor >2 && changeColor <=5)
            {
                spriteRenderer.color = new Color(0f, 1f, 0.02f, 1f);//Green
                isRed = false;
                isGreen = true;
                isBlue = false;
            }
            else
            {
                spriteRenderer.color = new Color(0f, 0.97f, 0.85f, 1f);//Blue
                isRed = false;
                isGreen = false;
                isBlue = true;
            }
        }
    }

    
   
           
    

}
