using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStep : MonoBehaviour
{

    [Header("Setting")]
    [SerializeField] private Camera cam;
    [SerializeField] private BoxCollider2D topWall;
    [SerializeField] private BoxCollider2D bottomWall;
    [SerializeField] private BoxCollider2D leftWall;
    [SerializeField] private BoxCollider2D rightWall;

    [SerializeField] private Transform playerGreen;
    [SerializeField] private Transform playerRed;

    public Vector3 mousePosition;
    public Vector2 screenMousePosition;


    // Start is called before the first frame update
    void Start()
    {
        topWall.size = new Vector2(cam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);//ScreenToWorldPoint 將螢幕座標轉換成世界座標
        topWall.offset = new Vector2(0f, cam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);//Screen.hright(螢幕最高的位置)

        bottomWall.size = new Vector2(cam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, cam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, cam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);



    }

    // Update is called once per frame
    void Update()
    {
        screenMousePosition = Input.mousePosition;




    }
}
