using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBlue : MonoBehaviour
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
            if (ballControlColor._isRed || ballControlColor._isBlue || ballControlColor._isGreen)
            {
                Debug.Log("CTACH");
            }

        }
    }
}
