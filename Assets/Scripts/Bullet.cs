using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 11)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
