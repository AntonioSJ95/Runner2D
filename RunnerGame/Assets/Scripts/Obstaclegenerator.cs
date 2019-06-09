using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclegenerator : MonoBehaviour
{
    public GameObject obstacle;
    public float respawntime;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coinWave());
    }

    private void spawnObstacle(){
        GameObject a = Instantiate(obstacle) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
    }


    IEnumerator coinWave()
    {
        while(true){
            yield return new WaitForSeconds(respawntime);
            spawnObstacle();
        }
        
    }
}
