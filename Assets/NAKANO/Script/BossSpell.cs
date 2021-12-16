using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    public float POWERG = 6;
    public static bool active = false;
    public static bool se = false;

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        se = true;

        if (active == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && se ==true)
        {
            se = false;
            Player1naka.PlayerHP -= POWERG;//PlayerÇ…çUåÇ
            Debug.Log("<color=red>Åö</color>" + POWERG + "ÇÃÉ_ÉÅÅ[ÉWÇéÛÇØÇΩ");
            Debug.Log("<color=blue>Åö</color>" + "HP" + Player1naka.PlayerHP);
            Invoke("SE", 1);
        }
    }

    void SE()
    {
        audioSource.PlayOneShot(sound1);
    }
}