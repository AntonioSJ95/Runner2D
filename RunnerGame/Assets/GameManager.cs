using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text currentScoreText;
     public int currentScore; 
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        currentScore++;
        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}
