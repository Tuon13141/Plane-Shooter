using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private bool canMove = false;
    void Start()
    {
        StartCoroutine(CanMove());
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
        
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        if(transform.position.x < -8)
        {
            transform.position = new Vector2(-8, this.transform.position.y);
        }
        else if(transform.position.x > 8)
        {
            transform.position = new Vector2(8, this.transform.position.y); 
        }

        if(transform.position.y < -10)
        {
            transform.position = new Vector2(this.transform.position.x, -10);
        }
        else if(transform.position.y > 10)
        {
            transform.position = new Vector2(this.transform.position.x, 10);
        }
    }

    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.5f);

        canMove = true;
    }
}
