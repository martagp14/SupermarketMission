using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{

    private bool[] correctness;

    private DropField[] dropFields = new DropField[6];

    void Start()
    {
        var num = FindObjectsOfType<DragAndDrop>().Length;
        correctness = new bool[num];
        for (int i = 0; i < correctness.Length; i++)
            correctness[i] = false;
        dropFields = FindObjectsOfType<DropField>();
    }

    public void OnClickCheckIfCorrect()
    {
        bool isCorrect = true;
        //Todo: Check is groceries are correctly classify
        //Check if pending item list is empty
        //Then check each category, run through every item and check its category propert
        for (int i = 0; i < dropFields.Length && isCorrect; i++)
        {
            Debug.Log("Estoy comprobando " + dropFields[i].GetComponent<DropField>());
            if (dropFields[i].isOccupied)
            {
                if (dropFields[i].getValue() != dropFields[i].element.getValue())
                {
                    isCorrect = false;
                    Debug.Log("Algo mal con " + dropFields[i].getValue());
                }
            }
            else
            {
                isCorrect = false;
            }
            
            
        }
        if (isCorrect)
        {
            Debug.Log("Todo cool");
        }
        else
        {
            Debug.Log("Algo not cool");
        }
    }

    public void SetResult(int index, bool value)
    {
        correctness[index] = value;
    }

    private bool CheckResults()
    {
        bool correct = true;
        for (int i = 0; correct && i < correctness.Length; i++)
        {
            if (!correctness[i])
                correct = false;
        }
        return correct;
    }

    public void OnClickCheck()
    {
        var correct = this.CheckResults();
        if (correct)
        {
            Debug.Log("Muy bien");
        }
        else
        {
            Debug.Log("Hay algo mal");
        }
    }

}
