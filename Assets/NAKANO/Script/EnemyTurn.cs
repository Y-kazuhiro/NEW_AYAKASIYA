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
        Player1 = GameObject.Find("Player1");  //Player�ϐ����L��
        player = Player1.GetComponent<Player1naka>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.P_turn == 0)
        {
            StartCoroutine("Move");
        }           
    }

    private IEnumerator Move()//�c�A���A�΂߈ړ�
    {
        int Enemy_X = Random.Range(-1, 2);

        int Enemy_Y = Random.Range(-1, 2);

        yield return new WaitForSeconds(0.3f);//�v���C���[�̍U�����I���܂ł�����Ƒ҂�

        transform.position += new Vector3(Enemy_X, Enemy_Y, 0);
    }
}
