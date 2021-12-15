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
    public static bool attack = false;//行動開始

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
            Debug.Log("再生");
            active = true;
            Invoke("BGM", 1);
            
        }


        if (active == true)
        {
        if (Player1naka.Spell == 0)
            {
                anim.SetTrigger("Spell");
                Invoke("Spell", 1);
            }
        }

        if (BossHP <= 0)//Bossの体力が０以下になると消える
        {           
            anim.SetTrigger("Die");
            BossHP = 1;
            Player1naka.PlayerEXP += BossEXP;
            Player1naka.NEXTPoint += BossPoint;
            Debug.Log("<color=blue>★</color>" + "経験値" + BossEXP + "ゲット");
            Debug.Log("<color=blue>★</color>" + "レベルアップまで" + Player1naka.PlayerEXP + "/ 100");
            if (Player1naka.GoalCount == 0)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1);

            if (Player1naka.GoalCount == 1)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2);

            if (Player1naka.GoalCount == 2)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3);

            if (Player1naka.GoalCount == 3)
                Debug.Log("ゴールまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4);
            Invoke("Die", 1);
        }
    }

    void BGM()
    {
        audioSource.PlayOneShot(sound1);
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
        }

    }
}

