using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���J�ڂ�����ꍇ�ɕK�v

public class f_Player1 : MonoBehaviour
{
    //�v���C���[���
    public float PlayerHP = 50;//HP
    public float PlayerPower = 2;//�U����
    public float PlayerSPAttack = 10;//�K�E�Z�g�p��

    public float P_turn = 2;//�v���C���[�^�[���@�@�Q��s��


    GameObject Enemy1;
    Enemy1 enemy;

    GameObject Enemy3;
    Enemy3 enemy3;

    GameObject EGhost;
    EGhost enemyG;

    GameObject LEnemy;
    LEnemy enemyL;

    Rigidbody2D rd2d;
    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;


    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Enemy1 = GameObject.Find("Enemy1");  //Enemy�ϐ����L��
        enemy = Enemy1.GetComponent<Enemy1>();

        Enemy3 = GameObject.Find("Enemy3");  //Enemy�ϐ����L��
        enemy3 = Enemy3.GetComponent<Enemy3>();

        EGhost = GameObject.Find("EGhost");  //Enemy�ϐ����L��
        enemyG = EGhost.GetComponent<EGhost>();

        LEnemy = GameObject.Find("LEnemy");  //Enemy�ϐ����L��
        enemyL = LEnemy.GetComponent<LEnemy>();
    }


    void Update()
    {

        if (P_turn != 0)
        {
            //-----------�v���C���[���ړ�����@�^�[�������--------------------
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                this.transform.Translate(0, 1, 0);
                anim.SetBool("��", true);

                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                this.transform.Translate(0, -1, 0);
                anim.SetBool("��", true);
                P_turn--;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                this.transform.Translate(1, 0, 0);
                anim.SetBool("�E", true);
                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                this.transform.Translate(-1, 0, 0);
                anim.SetBool("��", true);
                P_turn--;
            }
            //------------------------------------------------------------------


            //------------�v���C���[�̕�����ς���@�^�[������Ȃ�----------------
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                anim.SetBool("��", true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                anim.SetBool("��", true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", true);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", true);
            }
            //----------------------------------------------------------------


            //�U��
            if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�ōU��
            {
                anim.SetTrigger("PlayerAttack");
                audioSource.PlayOneShot(sound1);
                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.Q))//�͈͕K�E�Z
            {
                if (PlayerSPAttack >= 0)
                {
                    SPattack();
                    P_turn--;
                }
                else
                    Debug.Log("�o���Ȃ�");
            }

            if (Input.GetKeyDown(KeyCode.E))//���K�E�Z
            {
                if (PlayerSPAttack >= 0)
                {
                    SPSPattack();
                    P_turn--;
                }
                else
                    Debug.Log("�o���Ȃ�");
            }
        }

        if (PlayerHP <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
        {
            anim.SetTrigger("Die");
            //StartCoroutine("Defeat");
            Destroy(this.gameObject, 1f);//�P�b��ɏ�����
        }

        StartCoroutine("Defeat");

    }

    IEnumerator Defeat()
    {
        if (P_turn == 0)
        {

            //enemy.E_turn = 2;
            //�b�҂�
            //yield return new WaitForSeconds(1.0f);
            yield return null;
            P_turn = 2;
        }

    }



    void SPattack()
    {
        anim.SetTrigger("SPattack");
        audioSource.PlayOneShot(sound3);
        PlayerHP += 2;
        PlayerSPAttack--;
    }

    void SPSPattack()
    {
        anim.SetTrigger("2SPattack");
        audioSource.PlayOneShot(sound3);
        PlayerHP += 2;
        PlayerSPAttack--;
    }

    void OnCollisionEnter2D(Collision2D collision)//�����蔻�菈��
    {

        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("�K�E�Z�I�I");
        //    //PlayerHP -= 2;//2�_���[�W
        //    //Debug.Log(PlayerHP);
        //}

        //if (collision.gameObject.tag == "stone")
        //{
        //    Debug.Log("�΃Q�b�g");
        //    PlayerHP += 5;//5��
        //    Debug.Log(PlayerHP);
        //}
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.EnemyHP -= PlayerPower;//Enemy�ɍU��
            Debug.Log(enemy.EnemyHP);
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            enemy3.EnemyHP3 -= PlayerPower;//Enemy�ɍU��
            Debug.Log(enemy3.EnemyHP3);
        }

        if (collision.gameObject.tag == "EGhost")
        {
            enemyG.EnemyHPG -= PlayerPower;//Enemy�ɍU��
            Debug.Log(enemyG.EnemyHPG);
        }

        if (collision.gameObject.tag == "LEnemy")
        {
            enemyL.EnemyHPL -= PlayerPower;//Enemy�ɍU��
            Debug.Log(enemyL.EnemyHPL);
        }

        if (collision.gameObject.tag == "stone")
        {
            Debug.Log("�΃Q�b�g");
            PlayerHP += 10;//10��
            Debug.Log(PlayerHP);
        }



        //if (collision.gameObject.tag == "Trap")
        //{
        //    Debug.Log("�g���b�v���I");
        //    PlayerHP -= 1;//�P�_���[�W
        //    Debug.Log(PlayerHP);
        //}

        //if (collision.gameObject.tag == "Goal")
        //{
        //    SceneManager.LoadScene("Clear");
        //}


        //if (collision.gameObject.tag == "Enemy" && collision.gameObject.tag == "Attack")
        //{
        //    Debug.Log("�����G�ɍU���I�I");
        //    enemyhp.EnemyHP -= 1;//1�_���[�W
        //    Debug.Log("<color=red>(�E�́E)</color>" + enemyhp.EnemyHP);
        //}

        //if (collision.gameObject.tag == "EnemyAttack")
        //{
        //    Debug.Log("�G�̍U���I�I");
        //    PlayerHP -= 1;//1�_���[�W
        //    PlayerHP -= (script.EnemyPOWER);//1�_���[�W
        //    Debug.Log("��" + PlayerHP);
        //}
    }



}