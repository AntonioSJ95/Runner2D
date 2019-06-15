using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
   public void GotoMainScene()
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
}


