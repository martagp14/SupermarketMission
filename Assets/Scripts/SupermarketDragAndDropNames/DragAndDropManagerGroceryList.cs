using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManagerGroceryList : MonoBehaviour
{
    //CREO QUE NO SE USA PARA NADA

    private bool[] correctness;
    [SerializeField]
    private GameObject elementsList;

    void Start()
    {
        var num = FindObjectsOfType<DropFieldGroceryList>().Length;
        correctness = new bool[num];
        for (int i = 0; i < correctness.Length; i++)
            correctness[i] = false;
    }

    public void SetResult(int index, bool value)
    {
        correctness[index] = value;
    }

    private bool CheckResults()
    {
        bool correct = true;
        if (elementsList.transform.childCount > 0)
        {
            correct = false;
        }
        else
        {
            for (int i = 0; correct && i < correctness.Length; i++)
            {
                if (!correctness[i])
                    correct = false;
            }
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
