using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSpell : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject spellLogo;
    public Sprite[] spellLogoSprites;

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
            StartCoroutine(ChangingSpellLogo());

            index++;

            if(index >= spellBullets.Length)
            {
                index = 0;
            }

            bullet = spellBullets[index];
        }
    }

    IEnumerator ChangingSpellLogo()
    {
        SpriteRenderer logoRenderer = spellLogo.GetComponent<SpriteRenderer>();
        logoRenderer.sprite = spellLogoSprites[index];
        spellLogo.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        spellLogo.SetActive(false);
    }
}
