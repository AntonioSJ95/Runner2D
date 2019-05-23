using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{
    GameManager gameManager;
    public GameObject gravity;
    private bool top;
    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    public float jumpForce = 800f; //Fuerza del salto
    private bool jumpAllowed = false;
    private bool jumpAllowedSky = false;
    private bool checkJump = false;

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
                if(Input.GetTouch(i).tapCount == 2)
                {
                    rb.gravityScale *= -1;
                    Rotation(); 
                    checkJump = !checkJump;
                    Flip();
                } 
            }
        }

        //Boleano para permitir ambos saltos sin que choquen
        if(checkJump == true)
        {
            SwipeCheckSky();
        } 
        if(checkJump == false)
        {
            SwipeCheck();
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
        JumpIfAllowed(); //Verifica si el salto es permitido
        JumpIfAllowedSky();
    }

    //Checa si esta disponible el salto en el suelo
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


    //Checa si esta disponible el salto en el cielo
    private void SwipeCheckSky()
    {
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        startTouchPosition = Input.GetTouch(0).position;
        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if(endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
            jumpAllowedSky = true;
        }
    }


    //Verifica si se puede saltar en el suelo
    public void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            rb.AddForce (Vector2.up  * jumpForce);
            jumpAllowed = false;
        }  
    }

    //Verifica si se puede saltar en el cielo
    public void JumpIfAllowedSky()
    {
        if(jumpAllowedSky)
        {
            rb.AddForce(Vector2.down * jumpForce);
            jumpAllowedSky = false;
        }
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
            Destroy(col.gameObject);
            gameManager.AddScore();
        }
    }
}
