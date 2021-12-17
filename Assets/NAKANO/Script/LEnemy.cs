using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEnemy : MonoBehaviour
{
    //�G���
    public float EnemyHPL = 10;
    public float EnemyPOWERL = 2;
    public float EnemyEXPL = 15;
    public float EnemyPointL = 2;
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
        if (EnemyHPL <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
        {
            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            EnemyHPL = 1;
            Player1naka.NEXTPoint += EnemyPointL;
            Player1naka.PlayerEXP += EnemyEXPL;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>��</color>" + "�o���l" + EnemyEXPL + "�Q�b�g");
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
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);//�P�b��ɏ�����
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERL;//Player�ɍU��
            Debug.Log("<color=red>��</color>" + EnemyPOWERL + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
        }
        //animator.SetTrigger("Death");   //�|���A�j���Ɉڍs

    }
}