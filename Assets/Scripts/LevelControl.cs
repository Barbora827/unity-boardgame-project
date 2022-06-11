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
    public GameObject modal;
    public GameObject shadow;
    public Button yesBtn;
    public Button noBtn;

    void Start(){
        modal.SetActive(false);
        shadow.SetActive(false);
        Button startbtn = startButton.GetComponent<Button>();
        startbtn.onClick.AddListener(StartTheGame);

        Button closebtn = closeButton.GetComponent<Button>();
        closebtn.onClick.AddListener(ClickToQuit);

        Button playbtn = playAgainButton.GetComponent<Button>();
        playbtn.onClick.AddListener(PlayAgainOnClick);
    }

    void ClickToQuit(){

        modal.SetActive(true);
        shadow.SetActive(true);
        Button yessir = yesBtn.GetComponent<Button>();
        yessir.onClick.AddListener(QuitGame);

        Button nope = noBtn.GetComponent<Button>();
        nope.onClick.AddListener(Modal);

    }

    void PlayAgainOnClick(){
        SceneManager.LoadScene("StartScene");  
    }

    void StartTheGame(){
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame(){
        Application.Quit();
    }

    void Modal(){
        modal.SetActive(false);
        shadow.SetActive(false);
    }
}
