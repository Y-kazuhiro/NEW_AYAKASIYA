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

    private IEnumerator Move()//�c�A���ړ�
    {
        int Enemy_Move = Random.Range(-1, 2);//-1,0,1���烉���_���擾����

        int Enemy_or= Random.Range(-1, 2);

        yield return new WaitForSeconds(0.3f);//�v���C���[�̍U�����I���܂ł�����Ƒ҂�

        if (Enemy_or == -1)
            transform.position += new Vector3(Enemy_Move,0,0);//���ړ�

        if (Enemy_or == 1) 
            transform.position += new Vector3(0,Enemy_Move, 0);//�c�ړ�
    }
}
