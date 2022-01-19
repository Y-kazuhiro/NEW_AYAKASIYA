using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    //�G���
    public float EnemyHP = 10;
    public float EnemyHPMAX = 10;
    public static float HP = 10;
    public static float HPMAX = 10;
    public float EnemyPOWER = 2;
    public float EnemyEXP = 5;
    public float EnemyPoint = 1;
    public float EnemyYouki = 1;

    public static bool Event = false;

    public bool isDamage = false;
    public SpriteRenderer sp;


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
        HP = EnemyHP;
        HPMAX = EnemyHPMAX;

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (EnemyHP < 0)
        {
            EnemyHP -= EnemyHP;
        }

        if (EnemyHP <= 0 && Event == false)//�̗͂��O�ȉ��ɂȂ�Ə�����
        {
            Event = true;

            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            Player1naka.PlayerEXP += EnemyEXP;
            Player1naka.NEXTPoint += EnemyPoint;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>��</color>" + "�o���l" + EnemyEXP + "�Q�b�g");
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
        Event = false;
        Destroy(this.gameObject);//�P�b��ɏ�����
    }




    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWER;//Player�ɍU��

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>��</color>" + EnemyPOWER + "�̃_���[�W���󂯂�");
            Debug.Log("<color=blue>��</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            isDamage = true;
        }
        //animator.SetTrigger("Death"); //�|���A�j���Ɉڍs



    }
    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35�b�_�ł���
                                               // �ʏ��Ԃɖ߂�
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}