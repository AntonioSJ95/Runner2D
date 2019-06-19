using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject mainPanel,tutorialPanel, gamePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTutorial()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void showGames()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void exitTutorial()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
        gamePanel.SetActive(false);
    }



}
