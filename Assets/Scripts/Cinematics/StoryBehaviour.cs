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

    // Start is called before the first frame update
    void Start()
    {
        storyCanvas.gameObject.SetActive(false);
        nameCanvas.gameObject.SetActive(true);

        lines = new string[numLines];
        lines[0] = "�<Nombre jugador>! �Puedes venir un momento, por favor?";
        lines[1] = "Aqu� est�s. Pues ver�s, tengo una misi�n para ti";
        lines[2] = "Tu padre iba ponerse a hacer la comida, pero al parecer nos faltan muchos ingredientes y tenemos un poco de prisa.";
        lines[3] = "�Crees que podr�as conseguirlos todos tu solo, agente <inicial del nombre jugador>?";
        lines[4] = "�Si? Te veo decidido. Pues aqu� tienes la lista. Prep�rate para la misi�n.";
    }

    // Update is called once per frame
    void Update()
    {
        if (storyCanvas.isActiveAndEnabled)
        {
            if (Input.GetKeyDown("space"))
            {
                //Skip story
                GameManager.GetInstance().GoToScene("GroceryList");
            }
        }
    }

    public void OnClickEnterName()
    {
        //Todo: Check is name Input is empty

        GameManager.GetInstance().playerName = nameInput.text;
        Debug.Log("Player Name: " + GameManager.GetInstance().playerName);
        storyCanvas.gameObject.SetActive(true);
        nameCanvas.gameObject.SetActive(false);

        //Todo: start comic animation
        dialogM.SetText(lines[0]);
        //DialogManager.CompleteTextRevealed += showNewText;

    }

    //void completedLine()
    //{
    //    DialogManager.CompleteTextRevealed += showNewText;
    //}

    public void showNewText()
    {
        Debug.Log("Next line");
        if (index < lines.Length - 1)
        {
            index++;
            dialogM.SetText(lines[index]);
        }
    }


}
