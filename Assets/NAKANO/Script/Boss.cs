using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //敵情報
    public float BossHP = 150;
    public float BossHPMAX = 150;
    public static float HP = 150;
    public static float HPMAX = 150;
    public float BossPOWER = 15;
    public float BossEXP = 500;
    public float BossPoint = 100;
    public static bool active = false;//行動開始
    public static bool attack = false;
    public static bool Voice = false;

    public static bool Event = false;

    public bool isDamage = false;
    public SpriteRenderer sp;


    Rigidbody2D rd2d;
    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;

    private GameObject[] EGhostObjects;  //GameObjectにPlayerObjectsを格納します

    void Start()
    {
        Voice = false;
        attack = false;
        Event = false;
        active = false;
        isDamage = false;

        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HP = BossHP;
        HPMAX = BossHPMAX;

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (BossHP < 0)
        {
            BossHP -= BossHP;
        }

        EGhostObjects = GameObject.FindGameObjectsWithTag("EGhost");

         if (EGhostObjects.Length == 0 && active == false)//EGhostが消えると動き出す
         {
            active = true;
        }

        if (BossHP <= 0 && Event == false)//体力が０以下になると消える
        {
            Event = true;

            Debug.Log("討伐完了");
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
            Player1naka.Spell += 1;

            BossSpell.active = true;

            GetComponent<BoxCollider2D>().enabled = false;

            //オブジェクトを取得
            GameObject obj = GameObject.Find("BGM");
            // 指定したオブジェクトを削除
            Destroy(obj);

            anim.SetTrigger("Die");
            Voice = true;

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
        Event = false;
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= BossPOWER;//Playerに攻撃

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>★</color>" + BossPOWER + "のダメージを受けた");
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            isDamage = true;
        }

    }
    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35秒点滅する
                                               // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}

