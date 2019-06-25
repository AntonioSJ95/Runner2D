using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exitScript : MonoBehaviour
{
    public GameObject mainPanel,tutorialPanel;
    
    public void exitTutorial()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }
}
