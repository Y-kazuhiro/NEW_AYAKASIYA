using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    public float POWERG = 6;
    public static bool active = false;

    //AudioSource audioSource;
    //public AudioClip sound1;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(active == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= POWERG;//Player�ɍU��
            Debug.Log("<color=red>��</color>" + POWERG + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
        }

    }
}