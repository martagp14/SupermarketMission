using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1;

    public void LoadNextLevel(string nameScene)
    {
        StartCoroutine(LoadLevel(nameScene));
    }

    IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }

    public void StartScene()
    {
        StartCoroutine(HideInnerDialog());
    }

    IEnumerator HideInnerDialog()
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
    }
}
