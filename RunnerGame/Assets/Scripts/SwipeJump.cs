using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{

    GameManager gameManager;

    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    public float jumpForce = 800f; //Fuerza del salto
    private bool jumpAllowed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck(); //Checa cada frame el salto
    }

    private void FixedUpdate()
    {
        JumpIfAllowed(); //Verifica si el salto es permitido
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        startTouchPosition = Input.GetTouch(0).position;

        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if(endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
            jumpAllowed = true;
        }
    }

    private void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            rb.AddForce (Vector2.up * jumpForce);
            jumpAllowed = false;
            
        }
    }
 void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
           
            Debug.Log("Jugador");
            Destroy(col.gameObject);
            gameManager.AddScore();
            
            
        }
    }
}
