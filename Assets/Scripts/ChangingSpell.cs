using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSpell : MonoBehaviour
{
    public Animator playerAnim;

    public GameObject[] spellBullets;
    public GameObject bullet;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        bullet = spellBullets[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            playerAnim.SetTrigger("PlayerChangingSpell");

            index++;

            if(index >= spellBullets.Length)
            {
                index = 0;
            }

            bullet = spellBullets[index];
        }
    }
}
