using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadeControl : MonoBehaviour
{
    
    public Image black;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Fading());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("Inicio");
    }
}
