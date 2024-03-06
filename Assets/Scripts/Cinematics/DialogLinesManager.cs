using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLinesManager : MonoBehaviour
{
    private string[] lines;

    private int index = 0;
    private int numLines = 5;

    [SerializeField]
    private DialogManager dialogM;

    // Start is called before the first frame update
    void Start()
    {
        lines = new string[numLines];
        lines[0] = "�<Nombre jugador>! �Puedes venir un momento, por favor?";
        lines[1] = "Aqu� est�s. Pues ver�s, tengo una misi�n para ti";
        lines[2] = "Tu padre iba ponerse a hacer la comida, pero al parecer nos faltan muchos ingredientes y tenemos un poco de prisa.";
        lines[3] = "�Crees que podr�as conseguirlos todos tu solo, agente <inicial del nombre jugador>?";
        lines[4] = "-	�Si? Te veo decidido. Pues aqu� tienes la lista. Prep�rate para la misi�n.";
    }

    void completedLine()
    {
        DialogManager.CompleteTextRevealed += showNewText;
    }

    void showNewText()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogM.SetText(lines[index]);
        }
    }
}
