using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGhost : MonoBehaviour
{
    //敵情報
    public float EnemyHPG = 10;
    public float EnemyHPGMAX = 10;
    public static float HP = 10;
    public static float HPMAX = 10;
    public float EnemyPOWERG = 2;
    public float EnemyEXPG = 50;
    public float EnemyPointG = 3;
    public float EnemyYouki = 1;

    public static bool Event = false;

    public bool isDamage = false;
    public SpriteRenderer sp;


    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        Event = false;
        isDamage = false;

        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HP = EnemyHPG;
        HPMAX = EnemyHPGMAX;

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (EnemyHPG <= 0 && Event == false)//体力が０以下になると消える
        {
            Event = true;

            if(EnemyHPG < 0)
            {
                EnemyHPG -= EnemyHPG;
            }

            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            Player1naka.PlayerEXP += EnemyEXPG;
            Player1naka.NEXTPoint += EnemyPointG;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>★</color>" + "経験値" + EnemyEXPG + "ゲット");
            Debug.Log("<color=blue>★</color>" + "レベルアップまで" + Player1naka.PlayerEXP + "/ 100");
            Debug.Log("<color=blue>★</color>" + "妖気を" + EnemyYouki + "個取得");
            Debug.Log("<color=blue>★</color>" + "現在の妖気数は" + Player1naka.Youki + "個");
            if (Player1naka.GoalCount == 0)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1);

            if (Player1naka.GoalCount == 1)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2);

            if (Player1naka.GoalCount == 2)
                Debug.Log("次のステージまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3);

            if (Player1naka.GoalCount == 3)
                Debug.Log("ゴールまで" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4);
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Event = false;
        Destroy(this.gameObject);//１秒後に消える
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERG;//Playerに攻撃

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>★</color>" + EnemyPOWERG + "のダメージを受けた");
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            isDamage = true;
        }
        //animator.SetTrigger("Death");   //倒れるアニメに移行

    }
    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35秒点滅する
                                               // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}