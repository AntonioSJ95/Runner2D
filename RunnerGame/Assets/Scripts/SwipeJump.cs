using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{
    GameManager gameManager;
   // public GameObject gravity;
    private bool top;
    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        for( var i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if(Input.GetTouch(i).tapCount == 1)
                {
                    rb.gravityScale *= -1;
                    Rotation(); 
                    Flip();
                } 
            }
        }
    }
    //Activa la rotacion del personaje
     void Rotation()
    {
        if(top == false)
        {
            transform.eulerAngles = new Vector3(0,0,180f); 
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        facingRight = !facingRight;
        top = !top;
    }


    private void FixedUpdate()
    {
    }

    //Voltea cara del personaje para estar bien orientado
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //Agrega Puntos
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
            addSpeed();
            Destroy(col.gameObject);
            gameManager.AddScore();
            
        }else if(col.gameObject.tag == "Obstacle")
       {
           Destroy(col.gameObject);
           GameManager.health -= 1;
       } 
    }

    void addSpeed()
    {
        if(GameObject.Find("Obstacles").GetComponent<Obstaclegenerator>().respawntime > 1.9f)
        {
            GameObject.Find("Obstacles").GetComponent<Obstaclegenerator>().respawntime += 0.05f;
        }
    }
}
