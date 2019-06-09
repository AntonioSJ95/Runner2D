using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(AudioSource))]
public class pauseScript : MonoBehaviour
{


    public AudioClip song;
    private AudioSource songSource;
    public bool paused;

    public GameObject jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        songSource = GetComponent<AudioSource>();
        paused = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            songSource.clip = song;
            songSource.Pause();
           jugador.GetComponent<SwipeJump>().enabled = false;
          
            
        }
        else if(!paused)
        {
            Time.timeScale = 1;
            songSource.clip = song;
            songSource.Play(0);
            jugador.GetComponent<SwipeJump>().enabled = true;
         
        }
    }

    
}
