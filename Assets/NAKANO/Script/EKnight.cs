using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKnight : MonoBehaviour
{
    //敵情報
    public float EnemyHPK = 12;
    public float EnemyPOWERK = 5;
    public float EnemyEXPK = 25;
    public float EnemyPointK = 5;
    public float EnemyYouki = 1;
    void Start()
    {

    }

    void Update()
    {
        if (EnemyHPK <= 0)//プレーヤーの体力が０以下になると消える
        {
            Destroy(this.gameObject);//１秒後に消える
            Player1naka.PlayerEXP += EnemyEXPK;
            Player1naka.NEXTPoint += EnemyPointK;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>★</color>" + "経験値" + EnemyEXPK + "ゲット");
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
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERK;//Playerに攻撃
            Debug.Log("<color=red>★</color>" + EnemyPOWERK + "のダメージを受けた");
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death");   //倒れるアニメに移行

    }
}