using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    //�G���
    public float EnemyHP3 = 10;
    public float EnemyPOWER3 = 2;
    public float EnemyEXP3 = 10;
    public float EnemyPoint3 = 1;
    public float EnemyYouki = 1;
    void Start()
    {
     
    }

    void Update()
    {
        if (EnemyHP3 <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
        {
            Destroy(this.gameObject);//�P�b��ɏ�����
            Player1naka.PlayerEXP += EnemyEXP3;
            Player1naka.NEXTPoint += EnemyPoint3;
            Player1naka.Youki += EnemyYouki;
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
            Player1naka.PlayerHP -= EnemyPOWER3;//Player�ɍU��
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death");   //�|���A�j���Ɉڍs

    }
}