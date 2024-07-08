using System;
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
    //[SerializeField]
    //private Canvas nameCanvas;
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

    private AgentDataCollector dataCollector;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance().PlayMusicClip(AudioManager.GetInstance().generalMusic);

        changeInProgress = false;
        storyCanvas.gameObject.SetActive(false);

        levelLoader = FindObjectOfType<LevelLoader>();
        levelIntroLoader = FindObjectOfType<LevelIntroLoader>();

        switch (SceneManager.GetActiveScene().name)
        {
            case "StartingCinematic":
                //nameCanvas.gameObject.SetActive(true);
                momAnimator.gameObject.SetActive(true);
                //dataCollector = FindObjectOfType<AgentDataCollector>();
                SetLines();
                StartCoroutine(showIntroMessage());
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
                if (SceneManager.GetActiveScene().name == "StartingCinematic")
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

    IEnumerator showIntroMessage()
    {
        levelIntroLoader.SetIntroText();
        levelIntroLoader.StartDarkTransition();
        yield return new WaitForSeconds(1f);
        //if(nameCanvas)
        //    nameCanvas.gameObject.SetActive(false);
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
                lines[0] = "�" + GameManager.GetInstance().playerName + "! �Puedes venir un momento, por favor?";
                lines[1] = "Aqu� est�s. Pues ver�s, tengo una misi�n para ti.";
                lines[2] = "Tu padre iba a ponerse a hacer la comida, pero al parecer nos faltan muchos ingredientes y tenemos un poco de prisa.";
                lines[3] = "�Crees que podr�as conseguirlos todos por tu cuenta, agente " + GameManager.GetInstance().playerInitial + "? ";
                lines[4] = "�Si? Veo la decisi�n en tus ojos. Pues aqu� tienes la lista. Prep�rate para la misi�n.";
                break;
            case "FinalCinematic":
                numLines = 6;
                lines = new string[numLines];
                lines[0] = "Por fin en la caja";
                lines[1] = "�Siguiente!";
                lines[2] = "�Ya has vuelto!";
                lines[3] = "Veamos cual ha sido tu desempe�o en esta misi�n�";
                lines[4] = CalculateScore();
                //Dependiendo estado de los alimentos sacar un dialogo distinto
                lines[5] = CalculateTrolleyScore();
                break;
            default:
                lines[0] = "[Dialogo no definido]";
                break;
        }
        
    }

    string CalculateScore()
    {
        string time = TimeSpan.FromSeconds(GameManager.GetInstance().currentSpentTime).ToString(@"mm\:ss\:ff");
        int numPickedItems = GameManager.GetInstance().pickedListItems;
        int totalItems = GameManager.GetInstance().bakeryFoodList.Count + GameManager.GetInstance().fruitFoodList.Count + GameManager.GetInstance().legumeFoodList.Count +
            GameManager.GetInstance().fridgeFoodList.Count + GameManager.GetInstance().fishFoodList.Count + GameManager.GetInstance().perfumeryFoodList.Count;
        return "Has tardado " + time + ", y has tra�do "+ numPickedItems+" de los "+ totalItems +" alimentos objetivo. Y adem�s quisiste traerte "+ GameManager.GetInstance().numWrongPickedItems+" que no hac�a falta.";
    }

    string CalculateTrolleyScore()
    {
        string line = "";
        int wrongPosition = GameManager.GetInstance().numElementsWrongPositionTrolley;
        int moderatePosition = GameManager.GetInstance().numElementsModeratePositionTrolley;
        if(wrongPosition == 0 && moderatePosition == 0)
        {
            line = "Y has tra�do todo en perfecto estado. Has organizado muy bien el carro, �enhorabuena!";
        }
        else if(wrongPosition==0&&moderatePosition<4)
        {
            line = "Y la mayor�a del carro est� en perfecto estado. Solo has tenido un par de errores leves que ya ir�s perfeccionando. �Muy bien!";
        }else if (wrongPosition == 0 && moderatePosition >= 4)
        {
            line = "Has tenido algunos fallos leves al colocar las cosas en el carro. Tienes que tener un poco m�s de cuidado, pero por suerte nada se ha roto.";
        }else
        {
            line = "Parece que alguno de los objetivos se ha roto. Tienes que prestar atenci�n qu� objetos pones encima de cu�les. Quiz�s tengas que volver a ir a hacer la compra...";
        }
        return line;
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
