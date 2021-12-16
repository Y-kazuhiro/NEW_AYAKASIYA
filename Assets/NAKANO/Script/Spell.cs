using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject spell;
    public GameObject spell1;
    public GameObject spell2;
    public static float Order = 0;

    private GameObject[] BossObjects;  //GameObject‚ÉPlayerObjects‚ðŠi”[‚µ‚Ü‚·

    void Start()
    {
        spell.SetActive(false);
        spell1.SetActive(false);
        spell2.SetActive(false);
    }

    void Update()
    {
        if(Player1naka.Spell == 0)
        {
            Order += 1;
        }

        if (Boss.attack == false)
        {
            spell.SetActive(false);
        }

        if (Boss.attack == true)
        {
            spell.SetActive(true);
        }

        if (Order % 2 == 1)
        {
            if (Boss.attack == false)
            {
                spell1.SetActive(false);
            }

            if (Boss.attack == true)
            {
                spell1.SetActive(true);
            }
        }

        if (Order % 2 == 0)
        {
            if (Boss.attack == false)
            {
                spell2.SetActive(false);
            }

            if (Boss.attack == true)
            {
                spell2.SetActive(true);
            }
        }

        if(BossSpell.active == true)
        {
            Destroy(this.gameObject);
        }

    }

}
