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

    // Start is called before the first frame update
    void Start()
    {
        storyCanvas.gameObject.SetActive(false);
        nameCanvas.gameObject.SetActive(true);
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
    }


}
