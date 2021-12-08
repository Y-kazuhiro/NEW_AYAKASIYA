using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn1 : MonoBehaviour
{

    GameObject Player1;
    Player1naka player;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player1");  //Player変数共有化
        player = Player1.GetComponent<Player1naka>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1naka.P_turn == 0)
        {
            StartCoroutine("Move");
        }
    }

    private IEnumerator Move()//縦、横移動
    {
        int Enemy_Move = Random.Range(-1, 2);//-1,0,1からランダム取得する

        int Enemy_or= Random.Range(-1, 2);

        yield return new WaitForSeconds(0.3f);//プレイヤーの攻撃が終わるまでちょっと待つ

        if (Enemy_or == -1)
            transform.position += new Vector3(Enemy_Move,0,0);//横移動

        if (Enemy_or == 1) 
            transform.position += new Vector3(0,Enemy_Move, 0);//縦移動
    }
}
