using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SettingsButtons : MonoBehaviour
{
    //for ingame settings
    public Button mainBtn;
    public Button resumeBtn;
    public Button musiconBtn;
    public Button musicoffBtn;
    public Button return2menuBtn;

    public GameObject settingsWindow;
    public GameObject musicOffBtn;

    //for player stats, xp
    public Button statsBtn, backBtn;
    public GameObject statsWindow;

    public GameObject shopWindow;
    public Button exitShop;


    void Start()
    {
        settingsWindow.SetActive(false);

        Button btn1 = mainBtn.GetComponent<Button>();
        btn1.onClick.AddListener(OpenSettings);

        Button btn2 = resumeBtn.GetComponent<Button>();
        btn2.onClick.AddListener(ResumeGame);

        Button btn3 = musiconBtn.GetComponent<Button>();
        btn3.onClick.AddListener(TurnOffMusic);

        Button btn4 = musicoffBtn.GetComponent<Button>();
        btn4.onClick.AddListener(TurnOnMusic);

        Button btn5 = return2menuBtn.GetComponent<Button>();
        btn5.onClick.AddListener(ReturnToMenu);


        ///////////////////////////////////////////////////////////////

        
        Button btn6 = statsBtn.GetComponent<Button>();
        btn6.onClick.AddListener(OpenStats);

        Button btn7 = backBtn.GetComponent<Button>();
        btn7.onClick.AddListener(ResumeGame);

        ///////////////////////////////////////////////////////////////
        
        Button btn8 = exitShop.GetComponent<Button>();
        btn8.onClick.AddListener(ExitShop);
    }

    private void OpenSettings()
    {
        Time.timeScale = 0;
        settingsWindow.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    private void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        settingsWindow.SetActive(false);
        statsWindow.SetActive(false);
        Time.timeScale = 1;
    }

    private void ExitShop()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");

        FindObjectOfType<AudioManager>().Stop("shop");
        FindObjectOfType<AudioManager>().Play("theme");
        
        shopWindow.SetActive(false);
    }

    private void TurnOffMusic()
    {
        musicOffBtn.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        FindObjectOfType<AudioManager>().Music(false);

    }

    private void TurnOnMusic()
    {
        musicOffBtn.SetActive(false);
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        FindObjectOfType<AudioManager>().Music(true);
    }

    private void ReturnToMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
        Application.Quit();
    }


    //////////////////////////////////////////////////////////////////////////

    private void OpenStats()
    {
        Time.timeScale = 0;
        statsWindow.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    //////////////////////////////////////////////////////////////////////////
    
}
