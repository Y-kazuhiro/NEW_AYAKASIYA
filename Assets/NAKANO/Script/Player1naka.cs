using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���J�ڂ�����ꍇ�ɕK�v



public class Player1naka : MonoBehaviour
{
    //�v���C���[���
    public static float PlayerHP = 120;//HP
    public static float PlayerHPMAX = 120;//HP���
    public static float PlayerHPSab = 50;//HP�ۊǗp
    public static float PlayerPower = 2;//�U����
    public static float PlayerPowerSub = 2;//�U���͕ۊǗp
    public static float PlayerSPAttack = 10;//�K�E�Z�g�p��
    public static float PlayerSPAttackSub = 10;//�K�E�Z�g�p�񐔕ۊǗp
    public static bool PlayerSPLock = false;//�K�E�Z���b�N
    public static float PlayerEXP = 0;//�o���l
    public static float NEXTPoint = 0;//�S�[���ɕK�v�ȃ|�C���g��
    public static float GoalCount = 0;
    public static float P_turn = 2;//�v���C���[�^�[���@�@�Q��s��
    public static float Youki = 0;//�d�C
    public static double P_turncount = 0;
    public static bool walk = false;//�A���ړ��h�~
    public static bool get = false;//�A���񕜖h�~
    double P = 0.5;

    public static float PlayerMUKI = 0;//�v���C���[�̌���

    public static double Spell = 4;

    //------------�S�[���ɕK�v�ȃ|�C���g----------
    public static float NEXTCOUNT1 = 5;
    public static float NEXTCOUNT2 = 15;
    public static float NEXTCOUNT3 = 25;
    public static float NEXTCOUNT4 = 35;
    //--------------------------------------------



    //�G�̏����擾����--------------------------------------------
    GameObject Enemy1;
    Enemy1 enemy;

    GameObject Enemy3;
    Enemy3 enemy3;

    GameObject EGhost;
    EGhost enemyG;

    GameObject EDarkGhost;
    EDarkGhost enemyDarkG;

    GameObject LEnemy;
    LEnemy enemyL;

    GameObject EKnight;
    EKnight enemyKnight;

    GameObject EGoblin;
    EGoblin enemyGoblin;

    GameObject EGoblin1;
    EGoblin1 enemyGoblin1;

    GameObject ETree;
    ETree enemyTree;

    GameObject Boss;
    Boss boss;
    //------------------------------------------------------------

    Rigidbody2D rd2d;
    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;

    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        //�G�̏����擾����-------------------------------------------------
        Enemy1 = GameObject.Find("Enemy1"); //Enemy�ϐ����L��
        enemy = Enemy1.GetComponent<Enemy1>();

        Enemy3 = GameObject.Find("Enemy3"); //Enemy�ϐ����L��
        enemy3 = Enemy3.GetComponent<Enemy3>();

        EGhost = GameObject.Find("EGhost"); //Enemy�ϐ����L��
        enemyG = EGhost.GetComponent<EGhost>();

        EDarkGhost = GameObject.Find("EDarkGhost"); //Enemy�ϐ����L��
        enemyDarkG = EDarkGhost.GetComponent<EDarkGhost>();

        LEnemy = GameObject.Find("LEnemy"); //Enemy�ϐ����L��
        enemyL = LEnemy.GetComponent<LEnemy>();

        EKnight = GameObject.Find("EKnight"); //Enemy�ϐ����L��
        enemyKnight = EKnight.GetComponent<EKnight>();

        EGoblin = GameObject.Find("EGoblin"); //Enemy�ϐ����L��
        enemyGoblin = EGoblin.GetComponent<EGoblin>();

        EGoblin1 = GameObject.Find("EGoblin1"); //Enemy�ϐ����L��
        enemyGoblin1 = EGoblin1.GetComponent<EGoblin1>();

        ETree = GameObject.Find("ETree"); //Enemy�ϐ����L��
        enemyTree = ETree.GetComponent<ETree>();

        Boss = GameObject.Find("Boss"); //Enemy�ϐ����L��
        boss = Boss.GetComponent<Boss>();
        //--------------------------------------------------------------------
    }

    void Update()
    {
        if (P_turn != 0)//�v���C���[�̃^�[�����c���Ă�����s���ł���
        {
            //-----------�v���C���[���ړ�����@�^�[�������--------------------
            if (Input.GetKeyDown(KeyCode.UpArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                this.transform.Translate(0, 1, 0);//���1�}�X�ړ�
                anim.SetBool("��", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 1;
                if (P_turn == 0)
                {
                    walk = true;
                    Invoke("Walk", 0.5f);
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                this.transform.Translate(0, -1, 0);//����1�}�X�ړ�
                anim.SetBool("��", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 2;
                if (P_turn == 0)
                {
                    walk = true;
                    Invoke("Walk", 0.5f);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                this.transform.Translate(1, 0, 0);//�E��1�}�X�ړ�
                anim.SetBool("�E", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 3;
                if (P_turn == 0)
                {
                    walk = true;
                    Invoke("Walk", 0.5f);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                this.transform.Translate(-1, 0, 0);//����1�}�X�ړ�
                anim.SetBool("��", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 4;
                if (P_turn == 0)
                {
                    walk = true;
                    Invoke("Walk", 0.5f);
                }
            }
            //------------------------------------------------------------------

            //------------�v���C���[�̕�����ς���@�^�[������Ȃ�----------------
            if (Input.GetKeyDown(KeyCode.W))//�������
            {
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                anim.SetBool("��", true);
                PlayerMUKI = 1;
            }

            if (Input.GetKeyDown(KeyCode.S))//��������
            {
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", false);
                anim.SetBool("��", true);
                PlayerMUKI = 2;
            }

            if (Input.GetKeyDown(KeyCode.D))//�E������
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", true);
                PlayerMUKI = 3;
            }

            if (Input.GetKeyDown(KeyCode.A))//��������
            {
                anim.SetBool("��", false);
                anim.SetBool("��", false);
                anim.SetBool("�E", false);
                anim.SetBool("��", true);
                PlayerMUKI = 4;
            }

            //----------------------------------------------------------------
            //�U��
            if (Input.GetKeyDown(KeyCode.Space) && walk == false)//�X�y�[�X�ōU��
            {
                anim.SetTrigger("PlayerAttack");
                audioSource.PlayOneShot(sound4);
                P_turn--;
                Spell--;
                walk = true;
                Invoke("Walk", 1);
            }

            if (Input.GetKeyDown(KeyCode.Q) && walk == false)//�͈͕K�E�Z
            {
                if (Youki >= 15)
                {
                    PlayerSPLock = true;
                }

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>�������Ă��Ȃ�</color>");
                    Debug.Log("<color=red>����ɕK�v�ȗd�C</color>" + Youki + "/15");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPattack();
                    P_turn--;
                    Spell--;
                    Debug.Log("�K�E�Z�c��" + PlayerSPAttack + "��");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }
                else if (PlayerSPAttack <= 0)
                {
                    Debug.Log("<color=red>�Z���o���Ȃ��I</color>");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && walk == false)//���K�E�Z
            {
                if (Youki >= 15)
                {
                    PlayerSPLock = true;
                }

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>�������Ă��Ȃ�</color>");
                    Debug.Log("<color=red>����ɕK�v�ȗd�C</color>" + Youki + "/15");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPSPattack();
                    P_turn--;
                    Spell--;
                    Debug.Log("�K�E�Z�c��" + PlayerSPAttack + "��"); ;
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }
                else if (PlayerSPAttack <= 0)
                { 
                    Debug.Log("<color=red>�Z���o���Ȃ��I</color>");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    Invoke("Walk", 1);
                }
                }
        }

        if(PlayerEXP>=100)//���x���A�b�v
        {
            audioSource.PlayOneShot(sound7);

            PlayerHPMAX += 10;
            PlayerHP = PlayerHPMAX;
            PlayerPower += 2;
            PlayerSPAttack += 2;

            Debug.Log("<color=blue>�����x���A�b�v�I</color>");
            Debug.Log("�̗͍ő�l + 10");
            Debug.Log("�U���͂� + 2");
            Debug.Log("�K�E�Z�� + 2");
            Debug.Log("-----------------------------------------------------");

            PlayerEXP = 0;
        }

        if (PlayerHP <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�ƃQ�[���I�[�o�[
        {
            audioSource.PlayOneShot(sound6);

            anim.SetTrigger("Die");
            PlayerHP = 1;
            Invoke("Die",2);
        }

        StartCoroutine("TurnReset");
    }

    void Walk()
    {
        walk = false;
    }

    //�V�[���ڍs�Ɠ����ɃX�e�[�^�X��������
    void Die()
    {
        PlayerHP = PlayerHPSab;
        PlayerHPMAX = PlayerHPSab;
        PlayerPower = PlayerPowerSub;
        PlayerSPAttack = PlayerSPAttackSub;
        PlayerSPLock = false;
        PlayerEXP = 0;
        GoalCount = 0;
        NEXTPoint = 0;
        Youki = 0;
        P_turncount = 0;
        P_turn = 0;
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator TurnReset()//�^�[�����Z�b�g����
    {
        if (P_turn == 0)
        {
            yield return null;
            P_turn = 2;//�^�[����
            P_turncount += P;
        }

        if (Spell == 0)
        {
            yield return null;
            Spell = 4;
        }
    }

    void SPattack()
    {
        anim.SetTrigger("SPattack");
        audioSource.PlayOneShot(sound3);
        PlayerSPAttack--;
    }

    void SPSPattack()
    {
        anim.SetTrigger("2SPattack");
        audioSource.PlayOneShot(sound3);
        PlayerSPAttack--;
    }

    //----------------------------------------//�����蔻�菈��---------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(sound1);
            enemy.EnemyHP -= PlayerPower;//Enemy�ɍU��
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemy.EnemyHP);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            audioSource.PlayOneShot(sound1);
            enemy3.EnemyHP3 -= PlayerPower;//Enemy3�ɍU��
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemy3.EnemyHP3);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "EGhost")
        {
            audioSource.PlayOneShot(sound1);
            enemyG.EnemyHPG -= PlayerPower;//EGhost�ɍU��
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyG.EnemyHPG);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "LEnemy")
        {
            audioSource.PlayOneShot(sound1);
            enemyL.EnemyHPL -= PlayerPower;//LEnemy�ɍU��
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyL.EnemyHPL);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "EDarkGhost")
        {
            audioSource.PlayOneShot(sound1);
            enemyDarkG.EnemyHPDG -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyDarkG.EnemyHPDG);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "EKnight")
        {
            audioSource.PlayOneShot(sound1);
            enemyKnight.EnemyHPK -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyKnight.EnemyHPK);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "EGoblin")
        {
            audioSource.PlayOneShot(sound1);
            enemyGoblin.EnemyHPGob -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyGoblin.EnemyHPGob);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "EGoblin1")
        {
            audioSource.PlayOneShot(sound1);
            enemyGoblin1.EnemyHPGob1 -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyGoblin1.EnemyHPGob1);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "ETree")
        {
            audioSource.PlayOneShot(sound1);
            enemyTree.EnemyHPT -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + enemyTree.EnemyHPT);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Boss")
        {
            audioSource.PlayOneShot(sound1);
            boss.BossHP -= PlayerPower;
            Debug.Log("<color=blue>��</color>" + PlayerPower + "�̃_���[�W��^����");
            Debug.Log("<color=red>��</color>" + "�GHP" + boss.BossHP);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "stone" && get == false)//�Ύ擾
        {
            audioSource.PlayOneShot(sound5);
            float stone = 10;
            float SPstone = 1;

            if (PlayerHP + stone >= PlayerHPMAX)
            {
                get = true;
                PlayerHP += PlayerHPMAX - PlayerHP;
                Debug.Log("<color=blue>��</color>" + "HP+" + stone);
                Debug.Log("<color=blue>��</color>" + "HP" + PlayerHP);
                PlayerSPAttack += SPstone;
                Debug.Log("<color=blue>��</color>" + "�K�E�Z��+" + SPstone);
                Debug.Log("<color=blue>��</color>" + "�K�E�Z����" + PlayerSPAttack + "��");
                Debug.Log("-----------------------------------------------------");

                Invoke("Get", 1);
            }
            else
            {
                get = true;
                PlayerHP += stone;//10��
                Debug.Log("<color=blue>��</color>" + "HP+" + stone);
                Debug.Log("<color=blue>��</color>" + "HP" + PlayerHP);
                PlayerSPAttack += SPstone;
                Debug.Log("<color=blue>��</color>" + "�K�E�Z��+" + SPstone);
                Debug.Log("<color=blue>��</color>" + "�K�E�Z����" + PlayerSPAttack + "��");
                Debug.Log("-----------------------------------------------------");

                Invoke("Get", 1);
            }


        }
        //----------------------------------�V�[���؂�ւ�----------------------------------------------
        if (collision.gameObject.tag == "Goal2")//��2�X�e�[�W�ɐi��
        {
            if (NEXTPoint >= NEXTCOUNT1)
            {
                SceneManager.LoadScene("Nakano3");
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>�|�C���g������Ȃ�</color>" + NEXTPoint + "/" + NEXTCOUNT1);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal3")//��R�X�e�[�W�ɐi��
        {
            if (NEXTPoint >= NEXTCOUNT2)
            {
                SceneManager.LoadScene("Nakano");
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>�|�C���g������Ȃ�</color>" + NEXTPoint + "/" + NEXTCOUNT2);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal")
        {
            if (NEXTPoint >= NEXTCOUNT3)
            {
                SceneManager.LoadScene("Nakano1");//��S�X�e�[�W�ɐi��
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>�|�C���g������Ȃ�</color>" + NEXTPoint + "/" + NEXTCOUNT3);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal1")
        {
            if (NEXTPoint >= NEXTCOUNT4)
            {
                SceneManager.LoadScene("Last");//���X�X�e
                GoalCount++;
                walk = false;
            }
            else
            {
                Debug.Log("<color=red>�|�C���g������Ȃ�</color>" + NEXTPoint + "/" + NEXTCOUNT4);
                Debug.Log("-----------------------------------------------------");
            }
        }

        if (collision.gameObject.tag == "Goal4")
        {
            PlayerHP = PlayerHPSab;
            PlayerHPMAX = PlayerHPSab;
            PlayerPower = PlayerPowerSub;
            PlayerSPAttack = PlayerSPAttackSub;
            PlayerSPLock = false;
            GoalCount = 0;
            PlayerEXP = 0;
            NEXTPoint = 0;
            Youki = 0;
            P_turncount = 0;
            P_turn = 0;
            SceneManager.LoadScene("Clear");//�N���A
            walk = false;
        }
    }
    void Get()
    {
        get = false;
    }
}