using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound,coinSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("hurt");
        coinSound = Resources.Load<AudioClip>("coin");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "playerHit":
            audioSrc.PlayOneShot(playerHitSound);
            break;
            case "coin":
            audioSrc.PlayOneShot(coinSound);
            break;
        }
    }
}
