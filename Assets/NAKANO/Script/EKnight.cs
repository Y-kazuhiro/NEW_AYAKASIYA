using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKnight : MonoBehaviour
{
    //�G���
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
        if (EnemyHPK <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
        {
            Destroy(this.gameObject);//�P�b��ɏ�����
            Player1naka.PlayerEXP += EnemyEXPK;
            Player1naka.NEXTPoint += EnemyPointK;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>��</color>" + "�o���l" + EnemyEXPK + "�Q�b�g");
            Debug.Log("<color=blue>��</color>" + "���x���A�b�v�܂�" + Player1naka.PlayerEXP + "/ 100");
            Debug.Log("<color=blue>��</color>" + "�d�C��" + EnemyYouki + "�擾");
            Debug.Log("<color=blue>��</color>" + "���݂̗d�C����" + Player1naka.Youki + "��");
            if (Player1naka.GoalCount == 0)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1);



            if (Player1naka.GoalCount == 1)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2);



            if (Player1naka.GoalCount == 2)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3);



            if (Player1naka.GoalCount == 3)
                Debug.Log("�S�[���܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERK;//Player�ɍU��
            Debug.Log("<color=red>��</color>" + EnemyPOWERK + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death");   //�|���A�j���Ɉڍs

    }
}