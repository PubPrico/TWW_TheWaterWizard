using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpell : MonoBehaviour
{
    public GameObject shootingAim, bullet;
    public SpriteRenderer spriteRend;
    public Sprite[] sprites;
    public float cd;
    public float speed;
    float timer;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        timer = cd;
    }

    // Update is called once per frame
    void Update()
    {
        //ChangingSpell changingSpell = gameObject.GetComponent<ChangingSpell>();
        //bullet = changingSpell.bullet;
        timer += Time.deltaTime;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space))
        {
            spriteRend.sprite = sprites[0];
            
        }
        
        if(x > 0)
        {
            Debug.Log("D key pressed");
            spriteRend.sprite = sprites[0];
            shootingAim.transform.position = new Vector3(1f, 0, 0);
        }
        else if(x < 0)
        {
            spriteRend.sprite = sprites[1];
            shootingAim.transform.position = new Vector3(-1f, 0, 0);
        }
        else if(y < 0)
        {
            spriteRend.sprite = sprites[2];
            shootingAim.transform.position = new Vector3(0, -1f, 0);
        }
        else if(y > 0)
        {
            spriteRend.sprite = sprites[3];
            shootingAim.transform.position = new Vector3(0, 1f, 0);
        }

        /*Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if(Input.GetMouseButtonDown(0) && timer >= cd)
        {
            Instantiate(bullet, shootingAim.transform.position, Quaternion.identity);

            timer = 0;
        }*/

    }
}
