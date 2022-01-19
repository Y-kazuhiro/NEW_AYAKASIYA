using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    public float POWERG = 10;
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
            Player1naka.PlayerHP -= POWERG;//Player�ɍU��

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>��</color>" + POWERG + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            Invoke("SE", 0.5f);
        }
    }

    void SE()
    {
        audioSource.PlayOneShot(sound1);
    }
}