using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEnd : MonoBehaviour
{
    public Animator animator;
    public GameObject FadeCanvas;

    public void End()
    {
        FadeCanvas.SetActive(true);
        LoadEndLevel();
    }

    public void LoadEndLevel()
    {
        int _number =-SceneManager.GetActiveScene().buildIndex;
        int number = 2 + _number;

        StartCoroutine(LoadEnd(SceneManager.GetActiveScene().buildIndex+number));
    }

    IEnumerator LoadEnd(int End)
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(End);

    }

}
