using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //敵情報
    public float BossHP = 50;
    public float BossPOWER = 10;
    public float BossEXP = 500;
    public float BossPoint = 100;
    public static bool active = false;//行動開始
    public static bool attack = false;
    public static bool Voice = false;

    Rigidbody2D rd2d;
    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;

    private GameObject[] EGhostObjects;  //GameObjectにPlayerObjectsを格納します

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        EGhostObjects = GameObject.FindGameObjectsWithTag("EGhost");

         if (EGhostObjects.Length == 0 && active == false)//EGhostが消えると動き出す
         {
            active = true;
        }

        if (BossHP <= 0)//Bossの体力が０以下になると消える
        {
            Player1naka.Spell += 1;

            BossSpell.active = true;

            GetComponent<BoxCollider2D>().enabled = false;

            //オブジェクトを取得
            GameObject obj = GameObject.Find("BGM");
            // 指定したオブジェクトを削除
            Destroy(obj);

            anim.SetTrigger("Die");
            Voice = true;
            BossHP = 1;
            Debug.Log("討伐完了");
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
        }

        if (active == true && BossSpell.active == false)
        {
            if (Player1naka.Spell == 0)
            {
                anim.SetTrigger("Spell");
                Invoke("Spell", 1);
            }
        }
    }

    void Spell()
    {
        attack = true;
        Invoke("Stop", 2);
    }

    void Stop()
    {
        attack = false;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= BossPOWER;//Playerに攻撃
            Debug.Log("<color=red>★</color>" + BossPOWER + "のダメージを受けた");
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
        }

    }
}

