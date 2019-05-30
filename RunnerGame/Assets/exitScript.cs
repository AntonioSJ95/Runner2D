using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exitScript : MonoBehaviour
{
    public GameObject mainPanel,tutorialPanel;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitTutorial()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }
}
