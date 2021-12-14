using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETree : MonoBehaviour
{
    //敵情報
    public float EnemyHPT = 20;
    public float EnemyPOWERT = 5;
    public float EnemyEXPT = 80;
    public float EnemyPointT = 8;
    public float EnemyYouki = 1;

    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (EnemyHPT <= 0)//プレーヤーの体力が０以下になると消える
        {
            audioSource.PlayOneShot(sound1);

            anim.SetTrigger("Die");
            EnemyHPT = 1;
            Player1naka.PlayerEXP += EnemyEXPT;
            Player1naka.NEXTPoint += EnemyPointT;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>★</color>" + "経験値" + EnemyEXPT + "ゲット");
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
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);//１秒後に消える
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERT;//Playerに攻撃
            Debug.Log("<color=red>★</color>" + EnemyPOWERT + "のダメージを受けた");
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death");   //倒れるアニメに移行

    }
}