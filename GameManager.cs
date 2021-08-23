using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject ball;

    private void Update()
    {
        if(DialogueTrigger.dialogueTrigger.ballActive == true)
        {
            ball.SetActive(true);
        }
    }
}
