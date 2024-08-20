using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.Find("Player");
        ShootingSpell shootingSpell = player.GetComponent<ShootingSpell>();

        Vector2 direction = Vector2.zero;

        if(shootingSpell.spriteRend.sprite == shootingSpell.sprites[0])
        {
            Debug.Log("Right");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.right;
        }
        else if(shootingSpell.spriteRend.sprite == shootingSpell.sprites[1])
        {
            Debug.Log("Left");
            transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = Vector2.right;
        }
        else if(shootingSpell.spriteRend.sprite == shootingSpell.sprites[2])
        {
            Debug.Log("Bottom");
            transform.rotation = Quaternion.Euler(0, 0, -90);
            direction = Vector2.down;
        }
        else if(shootingSpell.spriteRend.sprite == shootingSpell.sprites[3])
        {
            Debug.Log("Top");
            transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = Vector2.up;
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
