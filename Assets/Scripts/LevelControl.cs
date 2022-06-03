using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Button startButton;
    public Button closeButton;
    public Button playAgainButton;

    void Start(){
        Button startbtn = startButton.GetComponent<Button>();
        startbtn.onClick.AddListener(StartTheGame);

        Button closebtn = closeButton.GetComponent<Button>();
        closebtn.onClick.AddListener(ClickToQuit);

        Button playbtn = playAgainButton.GetComponent<Button>();
        playbtn.onClick.AddListener(PlayAgainOnClick);
    }

    void ClickToQuit(){
        Application.Quit();
    }

    void PlayAgainOnClick(){
        SceneManager.LoadScene("StartScene");  
    }

    void StartTheGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
