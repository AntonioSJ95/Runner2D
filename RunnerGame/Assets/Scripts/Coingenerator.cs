using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coingenerator : MonoBehaviour
{
    public GameObject coin;
    public float respawntime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coinWave());
    }

    private void spawnCoin(){
        GameObject a = Instantiate(coin) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator coinWave()
    {
        while(true){
            yield return new WaitForSeconds(respawntime);
            spawnCoin();
        }
        
    }
}
