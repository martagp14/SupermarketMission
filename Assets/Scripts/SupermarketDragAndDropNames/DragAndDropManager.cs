using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{

    private bool[] correctness;

    void Start()
    {
        var num = FindObjectsOfType<DragAndDrop>().Length;
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
