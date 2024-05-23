using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryBehaviour : MonoBehaviour
{
    [SerializeField]
    private Canvas storyCanvas;
    [SerializeField]
    private Canvas nameCanvas;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private DialogManager dialogM;

    private string[] lines;

    private int index = 0;
    private int numLines = 5;

    private bool changeInProgress;

    private LevelLoader levelLoader;
    private LevelIntroLoader levelIntroLoader;

    [SerializeField] private Animator momAnimator;

    [Header("StartCinematic")]
    //[SerializeField] private Animator momAnimator;

    [Header("EndCinematic")]
    [SerializeField] private Image image;
    [SerializeField] private Image imageCharacter;
    [SerializeField] private Sprite imageGarden;
    //[SerializeField] private Sprite imageMum;


    // Start is called before the first frame update
    void Start()
    {
        changeInProgress = false;
        storyCanvas.gameObject.SetActive(false);

        levelLoader = FindObjectOfType<LevelLoader>();
        levelIntroLoader = FindObjectOfType<LevelIntroLoader>();

        switch (SceneManager.GetActiveScene().name)
        {
            case "StartingCinematic":
                nameCanvas.gameObject.SetActive(true);
                momAnimator.gameObject.SetActive(true);

                break;
            case "FinalCinematic":
                momAnimator.gameObject.SetActive(false);

                SetLines();
                StartCoroutine(showIntroMessage());
                break;
            default:
                break;
        }

        ////levelLoader.StartScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (storyCanvas.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                //Skip story
                levelLoader.LoadNextLevel("GroceryList");
            }
        }
    }

    public void OnClickEnterName()
    {
        //Todo: Check is name Input is empty

        GameManager.GetInstance().playerName = nameInput.text;
        var initial = GameManager.GetInstance().playerName.Substring(0, 1).ToUpper();
        GameManager.GetInstance().playerInitial = initial;
        Debug.Log("Player Name: " + GameManager.GetInstance().playerName);
        SetLines();
        //levelLoader.StartTransition();
        StartCoroutine(showIntroMessage());
        //Todo: start comic animation
    }

    IEnumerator showIntroMessage()
    {
        levelIntroLoader.SetIntroText();
        levelIntroLoader.StartDarkTransition();
        yield return new WaitForSeconds(1f);
        if(nameCanvas)
            nameCanvas.gameObject.SetActive(false);
        storyCanvas.gameObject.SetActive(true);
        dialogM.SetText(lines[0]);
    }

    void SetLines()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "StartingCinematic":
                numLines = 5;
                lines = new string[numLines];
                lines[0] = "¡" + GameManager.GetInstance().playerName + "! ¿Puedes venir un momento, por favor?";
                lines[1] = "Aquí estás. Pues verás, tengo una misión para ti.";
                lines[2] = "Tu padre iba ponerse a hacer la comida, pero al parecer nos faltan muchos ingredientes y tenemos un poco de prisa.";
                lines[3] = "¿Crees que podrías conseguirlos todos por tu cuenta, agente " + GameManager.GetInstance().playerInitial + "? ";
                lines[4] = "¿Si? Te veo decidido. Pues aquí tienes la lista. Prepárate para la misión.";
                break;
            case "FinalCinematic":
                numLines = 6;
                lines = new string[numLines];
                lines[0] = "Por fin en la caja";
                lines[1] = "¡Siguiente!";
                lines[2] = "¡Ya has vuelto!";
                lines[3] = "Veamos cual ha sido tu desempeño en esta misión…";
                lines[4] = "Has tardado <Insertar tiempo>, y has traído <Numero de elementos> de los <numero total de elementos> alimentos objetivo.";
                //Dependiendo estado de los alimentos sacar un dialogo distinto
                lines[5] = "¡Y todo esta en perfecto estado! Muy bien organizado";
                break;
            default:
                lines[0] = "[Dialogo no definido]";
                break;
        }
        
    }

    //void completedLine()
    //{
    //    DialogManager.CompleteTextRevealed += showNewText;
    //}

    public void ShowNewText()
    {
        if (!changeInProgress)
        {
            Debug.Log("Next line");
            if (index < lines.Length - 1)
            {
                index++;
                dialogM.SetText(lines[index]);
                ChangeStoryImage();

            }
            else
            {
                if (index == lines.Length - 1)
                {
                    if(SceneManager.GetActiveScene().name == "StartingCinematic")
                    {
                        //Skip story
                        levelLoader.LoadNextLevel("GroceryList");
                    }
                    else
                    {
                        levelLoader.LoadNextLevel("MainMenu");
                    }

                }
            }
        }
    }

    private void ChangeStoryImage()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "StartingCinematic":
                momAnimator.SetTrigger("Talk");
                break;
            case "FinalCinematic":
                if (index == 1)
                {
                    StartCoroutine(changeBackground());
                }
                momAnimator.SetTrigger("Talk");
                break;
            default:
                break;
        }
    }

    IEnumerator changeBackground()
    {
        changeInProgress = true;
        yield return new WaitForSeconds(2f);
        levelLoader.StartFakeTransition();
        yield return new WaitForSeconds(1f);
        changeInProgress = false;
        image.sprite = imageGarden;
        //imageCharacter.sprite = imageMum;
        momAnimator.gameObject.SetActive(true);
        ShowNewText();
        
    }
}
