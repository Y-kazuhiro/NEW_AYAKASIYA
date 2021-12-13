using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //�G���
    public float BossHP = 50;
    public float BossPOWER = 10;
    public float BossEXP = 500;
    public float BossPoint = 100;

    Animator anim;

    void Start()
    {

    }

    void Update()
    {
        if (BossHP <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
        {
            Destroy(this.gameObject);//�P�b��ɏ�����
            Player1naka.PlayerEXP += BossEXP;
            Player1naka.NEXTPoint += BossPoint;
            Debug.Log("<color=blue>��</color>" + "�o���l" + BossEXP + "�Q�b�g");
            Debug.Log("<color=blue>��</color>" + "���x���A�b�v�܂�" + Player1naka.PlayerEXP + "/ 100");
            if (Player1naka.GoalCount == 0)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1);

            if (Player1naka.GoalCount == 1)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2);

            if (Player1naka.GoalCount == 2)
                Debug.Log("���̃X�e�[�W�܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3);

            if (Player1naka.GoalCount == 3)
                Debug.Log("�S�[���܂�" + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4);
        }

        if (BossHP <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�ƃQ�[���I�[�o�[
        {
            anim.SetTrigger("Die");
            BossHP = 1;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= BossPOWER;//Player�ɍU��
            Debug.Log("<color=red>��</color>" + BossPOWER + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
        }
        //animator.SetTrigger("Death");   //�|���A�j���Ɉڍs

    }
}

