using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Animator anim;
    AudioSource audi;
    Rigidbody2D rb;
    public float speed;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        audi = gameObject.GetComponent<AudioSource>();
        audi.Play();
        rb = gameObject.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.Find("Player");
        ShootingSpell shootingSpell = player.GetComponent<ShootingSpell>();

        Vector2 direction = Vector2.zero;

        if(anim.GetBool("IsFacingDown"))
        {
            Debug.Log("Right");
            transform.rotation = Quaternion.Euler(0, 0, -90);
            direction = Vector2.down;
        }
        else if(anim.GetBool("IsFacingUp"))
        {
            Debug.Log("Left");
            transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = Vector2.up;
        }
        else if(anim.GetBool("IsFacingRight"))
        {
            Debug.Log("Bottom");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.right;
        }
        else if(anim.GetBool("IsFacingLeft"))
        {
            Debug.Log("Top");
            transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = Vector2.left;
        }

        rb.velocity = direction * speed;
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject player = GameObject.Find("Player");
        ChangingSpell changingSpell = player.GetComponent<ChangingSpell>();
        Sprite spellSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        if(collider.CompareTag("FireEnemy") && gameObject.CompareTag("WaterBullet"))
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
        else if(collider.CompareTag("TreeEnemy") && gameObject.CompareTag("FireBullet"))
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
        else if(collider.CompareTag("FireEnemy") || collider.CompareTag("TreeEnemy") || collider.CompareTag("WaterEnemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
