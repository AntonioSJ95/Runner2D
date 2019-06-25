using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform neighbour;

    public void Move()
    {
        transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
    }

     public void SnapToNeighbour()
    {
        transform.position = new Vector2(neighbour.position.x, transform.position.y);
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Reset")
        {
            SnapToNeighbour();
        }
    }   
}
