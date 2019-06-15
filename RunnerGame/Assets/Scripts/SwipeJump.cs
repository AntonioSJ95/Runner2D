using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{
    GameManager gameManager;
   // public GameObject gravity;
    private bool top;
    private Vector2 startTouchPosition, endTouchPosition;
    public Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
  public  void Update()
    {
                if(Input.GetMouseButtonDown(0) && isGrounded == true)
                {
                    rb.gravityScale *= -1;
                    Rotation(); 
                    Flip();
                }
    }
    //Activa la rotacion del personaje
     public void Rotation()
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    //Voltea cara del personaje para estar bien orientado
   public void Flip()
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
            soundManagerScript.PlaySound("coin");
            HealthBarScript.health += 7f;
            addSpeed();
            Destroy(col.gameObject);
            gameManager.AddScore();
            
        }
        else if(col.gameObject.tag == "Obstacle")
       {    
           soundManagerScript.PlaySound("playerHit");
           HealthBarScript.health -= 5f;
           Destroy(col.gameObject);
           GameManager.health -= 1;
           
       } 
    }

    void addSpeed()
    {
        if(GameObject.Find("Obstacles").GetComponent<Obstaclegenerator>().respawntime > 0.50f)
        {
            GameObject.Find("Obstacles").GetComponent<Obstaclegenerator>().respawntime -= 0.02f;
        }
    }
}
