using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    

    public void RetryButton()
    {
        SceneManager.LoadScene("Retry");
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("End");
    }

    public void Exit()
    {
        Application.Quit();
    }

    

}
