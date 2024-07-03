using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private object playButton;
    [SerializeField] Canvas scorebardCanvas;
    [SerializeField] Canvas optionsCanvas;
    [SerializeField] Canvas mainCanvas;


    // Start is called before the first frame update
    void Start()
    {
        scorebardCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        AudioManager.GetInstance().PlayMusicClip(AudioManager.GetInstance().generalMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        GameManager.GetInstance().GoToScene("NameScene");
    }

    public void OnClickScoreboard()
    {
        Debug.Log("Clicked Scoreboard");
    }

    public void OnClickOptions()
    {
        Debug.Log("Clicked Options");
        scorebardCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(!optionsCanvas.gameObject.activeSelf);
        //mainCanvas.gameObject.SetActive(!mainCanvas.gameObject.activeSelf);
    }

    public void OnClickExit()
    {
        Debug.Log("Clicked Exit");
        Application.Quit();
    }

    public void OnClickDaltonic()
    {
        GameManager.GetInstance().daltonicUser = !GameManager.GetInstance().daltonicUser;
    }
}
