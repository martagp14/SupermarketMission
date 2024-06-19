using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExplanationCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void SetText(int index, string newText)
    {
        if (GameManager.GetInstance().firstTimeScene[index])
        {
            text.text = newText;
            GameManager.GetInstance().firstTimeScene[index] = false;
        }
        else
        {
            this.Close();
        }
    }
}
