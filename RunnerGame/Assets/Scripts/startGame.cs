using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
   public void GoToClasic()
    {
        SceneManager.LoadScene("Juego");
    }

    public void ResetHardcore()
    {
        SceneManager.LoadScene("Hardcore");
    }

      public void MainMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void GoToOnekill()
    {
        SceneManager.LoadScene("Onekill");
    }
}


