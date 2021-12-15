using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject spell;
    public GameObject spell1;

    void Start()
    {
        spell.SetActive(false);
        spell1.SetActive(false);
    }

    void Update()
    {
        if(Boss.attack == false)
        {
            spell.SetActive(false);
        }

        if(Boss.attack == true)
        {
            spell.SetActive(true);
        }


        if (Boss.attack == false)
        {
            spell1.SetActive(false);
        }

        if (Boss.attack == true)
        {
            spell1.SetActive(true);
        }
    }

}
