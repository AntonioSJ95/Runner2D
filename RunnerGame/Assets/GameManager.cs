using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text currentScoreText;
     public int currentScore;

     public GameObject heart1, heart2, heart3, character;
     public static int health; 
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        SetScore();
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 3)
        health = 3;

        switch (health) 
        {
            case 3:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            break;
            case 2:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            break;
            case 1:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
            break;
            case 0:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            character.gameObject.SetActive(false);
            Time.timeScale = 0;
            break;
        }
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
