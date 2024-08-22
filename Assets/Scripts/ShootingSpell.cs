using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpell : MonoBehaviour
{
    public Animator anim;
    public GameObject shootingAim, bullet;
    public float cd;
    public float speed;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = cd;
    }

    // Update is called once per frame
    void Update()
    {
        ChangingSpell changingSpell = gameObject.GetComponent<ChangingSpell>();
        bullet = changingSpell.bullet;
        timer += Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsFacingDown", true);
            anim.SetBool("IsFacingUp", false);
            anim.SetBool("IsFacingRight", false);
            anim.SetBool("IsFacingLeft", false);
            shootingAim.transform.position = new Vector3(0, -1f, 0);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsFacingDown", false);
            anim.SetBool("IsFacingUp", true);
            anim.SetBool("IsFacingRight", false);
            anim.SetBool("IsFacingLeft", false);
            shootingAim.transform.position = new Vector3(0, 1f, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D key pressed");
            anim.SetBool("IsFacingDown", false);
            anim.SetBool("IsFacingUp", false);
            anim.SetBool("IsFacingRight", true);
            anim.SetBool("IsFacingLeft", false);
            shootingAim.transform.position = new Vector3(1f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("IsFacingDown", false);
            anim.SetBool("IsFacingUp", false);
            anim.SetBool("IsFacingRight", false);
            anim.SetBool("IsFacingLeft", true);
            shootingAim.transform.position = new Vector3(-1f, 0, 0);
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if(Input.GetMouseButtonDown(0) && timer >= cd)
        {
            Instantiate(bullet, shootingAim.transform.position, Quaternion.identity);

            timer = 0;
        }

    }
}
