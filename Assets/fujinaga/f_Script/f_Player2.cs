using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���J�ڂ�����ꍇ�ɕK�v

public class f_Player2 : MonoBehaviour
{
    //public float speed = 100.0F;
    public float PlayerHP = 10;

    //GameObject enemy;
    //Enemy1 enemyhp;

    Rigidbody2D rd2d;
    //Animator anim;
    //public AudioClip sound1;
    //public AudioClip sound2;
    //AudioSource audioSource;


    void Start()
    {
        //anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        //enemy = GameObject.Find("Enemy1");  //EnemyHP�ϐ����L��
        //enemyhp = enemy.GetComponent<Enemy1>();
    }


    //    void Update()
    //    {

    //        //Debug.Log("Inputed");
    //        // ���L�[�̓��͏����擾
    //        //float horizontalKey = Input.GetAxis("Horizontal");
    //        //float vertical = Input.GetAxis("Vertical");

    //        //if (horizontalKey > 0)
    //        //{
    //        //    transform.localScale = new Vector3(-1, 1, 1);
    //        //    anim.SetFloat("Walk_X",horizontalKey);
    //        //    Debug.Log("�E");
    //        //}

    //        //else if (horizontalKey < 0)
    //        //{
    //        //    transform.localScale = new Vector3(1, 1, 1);
    //        //    anim.SetFloat("Walk_X",horizontalKey);
    //        //    Debug.Log("��");
    //        //}

    //        //else if (vertical > 0)
    //        //{
    //        //    anim.SetFloat("Walk_Y", vertical);
    //        //    Debug.Log("��");
    //        //}

    //        //else if (vertical < 0)
    //        //{
    //        //    anim.SetFloat("Walk_-Y", vertical);
    //        //    Debug.Log("��");
    //        //}

    //        //Vector3 scale = transform.localScale;

    //        if (Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            audioSource.PlayOneShot(sound2);
    //            anim.SetBool("��", false);
    //            anim.SetBool("�E", false);
    //            anim.SetBool("��", false);
    //            this.transform.Translate(0, 1, 0);
    //            anim.SetBool("��", true);
    //            //StartCoroutine("Defeat");

    //        }
    //        if (Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            audioSource.PlayOneShot(sound2);
    //            anim.SetBool("��", false);
    //            anim.SetBool("�E", false);
    //            anim.SetBool("��", false);
    //            this.transform.Translate(0, -1, 0);
    //            anim.SetBool("��", true);
    //        }

    //        if (Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            //transform.localScale = new Vector3(-3, 3, 3);
    //            anim.SetBool("��", false);
    //            anim.SetBool("��", false);
    //            anim.SetBool("��", false);
    //            this.transform.Translate(1, 0, 0);
    //            anim.SetBool("�E", true);

    //            //scale.x = 1;
    //        }
    //        if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        {
    //            //transform.localScale = new Vector3(3, 3, 3);
    //            anim.SetBool("��", false);
    //            anim.SetBool("��", false);
    //            anim.SetBool("�E", false);
    //            this.transform.Translate(-1, 0, 0);
    //            anim.SetBool("��", true);
    //            //scale.x = -1;
    //        }


    //        //transform.localScale = scale;

    //        //else if (vertical == 0 && horizontalKey == 0)
    //        //    anim.SetBool("walk_X", true);

    //        //// �ړ�����������쐬����
    //        //Vector2 direction = new Vector2(horizontalKey, vertical).normalized;

    //        //// �ړ���������ƃX�s�[�h���� 
    //        //rd2d.velocity = direction * speed;

    //        //�U��
    //        if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�ōU��
    //        {
    //            anim.SetTrigger("PlayerAttack");
    //            audioSource.PlayOneShot(sound1);
    //            //Debug.Log("�U��");
    //            //Debug.Log(enemyhp.EnemyHP);

    //        }
    //        //if(Input.GetKeyDown(KeyCode.Space)&&Input.GetKeyDown(KeyCode.LeftControl))
    //        if (Input.GetKeyDown(KeyCode.A))
    //        {
    //            anim.SetTrigger("SPattack");

    //        }

    //        if (PlayerHP <= 0)//�v���[���[�̗̑͂��O�ȉ��ɂȂ�Ə�����
    //        {
    //            anim.SetTrigger("Die");
    //            //StartCoroutine("Defeat");
    //            Destroy(this.gameObject, 1f);//�P�b��ɏ�����
    //        }

    //        //    GameObject Enemy = GameObject.Find("Enemy");

    //        //    if (enemyhp.EnemyHP <= 0)
    //        //    {
    //        //        Destroy(Enemy);
    //        //    }

    //        //}

    //        //private IEnumerator Defeat()
    //        //{
    //        //    //1�b�҂�
    //        //    yield return new WaitForSeconds(5.0f);
    //        //}

    //    }


    //void OnCollisionEnter2D(Collision2D collision)//�����蔻�菈��
    //{

    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    Debug.Log("�G���ڐG�I�I");
    //    //    PlayerHP -= 2;//2�_���[�W
    //    //    Debug.Log(PlayerHP);
    //    //}

    //    //if (collision.gameObject.tag == "stone")
    //    //{
    //    //    Debug.Log("�΃Q�b�g");
    //    //    PlayerHP += 5;//5��
    //    //    Debug.Log(PlayerHP);
    //    //}
    //}


    //    void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            Debug.Log("�G���ڐG�I�I");
    //            PlayerHP -= 2;//2�_���[�W
    //            Debug.Log(PlayerHP);
    //        }

    //        if (collision.gameObject.tag == "stone")
    //        {
    //            Debug.Log("�΃Q�b�g");
    //            PlayerHP += 5;//5��
    //            Debug.Log(PlayerHP);
    //        }


    //        //if (collision.gameObject.tag == "Trap")
    //        //{
    //        //    Debug.Log("�g���b�v���I");
    //        //    PlayerHP -= 1;//�P�_���[�W
    //        //    Debug.Log(PlayerHP);
    //        //}

    //        //if (collision.gameObject.tag == "Goal")
    //        //{
    //        //    SceneManager.LoadScene("Clear");
    //        //}


    //        //if (collision.gameObject.tag == "Enemy" && collision.gameObject.tag == "Attack")
    //        //{
    //        //    Debug.Log("�����G�ɍU���I�I");
    //        //    enemyhp.EnemyHP -= 1;//1�_���[�W
    //        //    Debug.Log("<color=red>(�E�́E)</color>" + enemyhp.EnemyHP);
    //        //}

    //        //if (collision.gameObject.tag == "EnemyAttack")
    //        //{
    //        //    Debug.Log("�G�̍U���I�I");
    //        //    PlayerHP -= 1;//1�_���[�W
    //        //    PlayerHP -= (script.EnemyPOWER);//1�_���[�W
    //        //    Debug.Log("��" + PlayerHP);
    //        //}
    //    }

}
