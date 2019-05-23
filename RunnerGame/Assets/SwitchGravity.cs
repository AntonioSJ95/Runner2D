using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    public Rigidbody2D rb;
    private SwipeJump player;

    private bool top;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
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
                }
            }
        }
    }

    void Rotation()
    {
        if(top == false)
        {
            transform.eulerAngles = new Vector3(0,0,180f);  
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }
}
