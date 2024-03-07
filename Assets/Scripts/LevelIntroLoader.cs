using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntroLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1;

    //Intro text
    //public string introSceneText;
    [SerializeField] TMP_Text introText;

    [SerializeField]
    private DialogManager dialogM;

    //private void Start()
    //{
    //    introSceneText = "¡" + GameManager.GetInstance().playerName + "! ¿Puedes venir un momento, por favor?";
    //}

    private void Start()
    {
        //Definir frases segun nombre escena
       
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartLightTransition();
        //}
    }

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

    //public void StartScene()
    //{
    //    StartCoroutine(HideInnerDialog());
    //}

    //IEnumerator HideInnerDialog()
    //{
    //    transition.SetTrigger("End");
    //    yield return new WaitForSeconds(transitionTime);
    //}

    public void StartDarkTransition()
    {
        Debug.Log("Oscurecer");
        StartCoroutine(showIntrotext());
    }

    IEnumerator showIntrotext()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        dialogM.SetText("¡" + GameManager.GetInstance().playerName + "! ¿Puedes venir un momento, por favor ? ");
    }

    public void StartLightTransition()
    {
        Debug.Log("Aclarar");
        transition.SetTrigger("End");
    }
}
