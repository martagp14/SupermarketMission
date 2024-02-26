using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private object playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        GameManager.GetInstance().GoToScene("StartingCinematic");
    }

    public void OnClickScoreboard()
    {
        Debug.Log("Clicked Scoreboard");
    }

    public void OnClickOptions()
    {
        Debug.Log("Clicked Options");
    }

    public void OnClickExit()
    {
        Debug.Log("Clicked Exit");
        Application.Quit();
    }
}
