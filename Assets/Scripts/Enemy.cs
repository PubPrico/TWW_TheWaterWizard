using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public Transform player;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 direction = transform.position - player.position;

        if (direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            rb.velocity = -transform.right * speed;
        }
        else if (direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = -transform.right * speed;
        }
        else if (direction.y > 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            rb.velocity = -transform.up * speed;
        }
        else if (direction.y < 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            rb.velocity = transform.up * speed;
        }
    }

    
}
