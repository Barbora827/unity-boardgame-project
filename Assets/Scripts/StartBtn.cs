using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{

    public Button startButton;

    void Start(){
        Button startbtn = startButton.GetComponent<Button>();
        startbtn.onClick.AddListener(StartTheGame);
        
    }
    
    void StartTheGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
