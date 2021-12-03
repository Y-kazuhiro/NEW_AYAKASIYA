using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy1 : MonoBehaviour
{
    //敵情報
    public float EnemyHP = 10;
    public float EnemyPOWER = 2;
    public float EnemyEXP = 10;
    public float EnemyPoint = 1;
    public float EnemyYouki = 1;



    void Start()
    {



    }



    void Update()
    {
        if (EnemyHP <= 0)//プレーヤーの体力が０以下になると消える
        {
            Destroy(this.gameObject);//１秒後に消える
            Player1naka.PlayerEXP += EnemyEXP;
            Player1naka.NEXTPoint += EnemyPoint;
            Player1naka.Youki += EnemyYouki;
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
            Player1naka.PlayerHP -= EnemyPOWER;//Playerに攻撃
            Debug.Log("<color=blue>★</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death"); //倒れるアニメに移行



    }
}