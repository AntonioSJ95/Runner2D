using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject mainPanel,tutorialPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTutorial()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }
}
