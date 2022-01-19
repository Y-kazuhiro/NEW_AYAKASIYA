using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGoblin : MonoBehaviour
{
    //�G���
    public float EnemyHPGob = 6;
    public float EnemyHPGobMAX = 6;
    public static float HP = 6;
    public static float HPMAX = 6;
    public float EnemyPOWERGob = 4;
    public float EnemyEXPGob = 10;
    public float EnemyPointGob = 1;
    public float EnemyYouki = 1;

    public static bool Event = false;

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
        HP = EnemyHPGob;
        HPMAX = EnemyHPGobMAX;

        if (EnemyHPGob < 0)
        {
            EnemyHPGob -= EnemyHPGob;
        }

        if (EnemyHPGob <= 0 && Event == false)//�̗͂��O�ȉ��ɂȂ�Ə�����
        {
            Event = true;

            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            Player1naka.PlayerEXP += EnemyEXPGob;
            Player1naka.NEXTPoint += EnemyPointGob;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>��</color>" + "�o���l" + EnemyEXPGob + "�Q�b�g");
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
            Player1naka.PlayerHP -= EnemyPOWERGob;//Player�ɍU��

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>��</color>" + EnemyPOWERGob + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
        }
        //animator.SetTrigger("Death");   //�|���A�j���Ɉڍs

    }
}