using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
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

    private IEnumerator Move()//縦、横、斜め移動
    {
        int Enemy_X = Random.Range(-1, 2);

        int Enemy_Y = Random.Range(-1, 2);

        yield return new WaitForSeconds(0.3f);//プレイヤーの攻撃が終わるまでちょっと待つ

        transform.position += new Vector3(Enemy_X, Enemy_Y, 0);
    }
}
