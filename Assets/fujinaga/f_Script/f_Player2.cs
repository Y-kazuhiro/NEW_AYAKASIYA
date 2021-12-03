using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移させる場合に必要

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
        //enemy = GameObject.Find("Enemy1");  //EnemyHP変数共有化
        //enemyhp = enemy.GetComponent<Enemy1>();
    }


    //    void Update()
    //    {

    //        //Debug.Log("Inputed");
    //        // 矢印キーの入力情報を取得
    //        //float horizontalKey = Input.GetAxis("Horizontal");
    //        //float vertical = Input.GetAxis("Vertical");

    //        //if (horizontalKey > 0)
    //        //{
    //        //    transform.localScale = new Vector3(-1, 1, 1);
    //        //    anim.SetFloat("Walk_X",horizontalKey);
    //        //    Debug.Log("右");
    //        //}

    //        //else if (horizontalKey < 0)
    //        //{
    //        //    transform.localScale = new Vector3(1, 1, 1);
    //        //    anim.SetFloat("Walk_X",horizontalKey);
    //        //    Debug.Log("左");
    //        //}

    //        //else if (vertical > 0)
    //        //{
    //        //    anim.SetFloat("Walk_Y", vertical);
    //        //    Debug.Log("上");
    //        //}

    //        //else if (vertical < 0)
    //        //{
    //        //    anim.SetFloat("Walk_-Y", vertical);
    //        //    Debug.Log("下");
    //        //}

    //        //Vector3 scale = transform.localScale;

    //        if (Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            audioSource.PlayOneShot(sound2);
    //            anim.SetBool("下", false);
    //            anim.SetBool("右", false);
    //            anim.SetBool("左", false);
    //            this.transform.Translate(0, 1, 0);
    //            anim.SetBool("上", true);
    //            //StartCoroutine("Defeat");

    //        }
    //        if (Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            audioSource.PlayOneShot(sound2);
    //            anim.SetBool("上", false);
    //            anim.SetBool("右", false);
    //            anim.SetBool("左", false);
    //            this.transform.Translate(0, -1, 0);
    //            anim.SetBool("下", true);
    //        }

    //        if (Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            //transform.localScale = new Vector3(-3, 3, 3);
    //            anim.SetBool("上", false);
    //            anim.SetBool("下", false);
    //            anim.SetBool("左", false);
    //            this.transform.Translate(1, 0, 0);
    //            anim.SetBool("右", true);

    //            //scale.x = 1;
    //        }
    //        if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        {
    //            //transform.localScale = new Vector3(3, 3, 3);
    //            anim.SetBool("上", false);
    //            anim.SetBool("下", false);
    //            anim.SetBool("右", false);
    //            this.transform.Translate(-1, 0, 0);
    //            anim.SetBool("左", true);
    //            //scale.x = -1;
    //        }


    //        //transform.localScale = scale;

    //        //else if (vertical == 0 && horizontalKey == 0)
    //        //    anim.SetBool("walk_X", true);

    //        //// 移動する向きを作成する
    //        //Vector2 direction = new Vector2(horizontalKey, vertical).normalized;

    //        //// 移動する向きとスピードを代入 
    //        //rd2d.velocity = direction * speed;

    //        //攻撃
    //        if (Input.GetKeyDown(KeyCode.Space))//スペースで攻撃
    //        {
    //            anim.SetTrigger("PlayerAttack");
    //            audioSource.PlayOneShot(sound1);
    //            //Debug.Log("攻撃");
    //            //Debug.Log(enemyhp.EnemyHP);

    //        }
    //        //if(Input.GetKeyDown(KeyCode.Space)&&Input.GetKeyDown(KeyCode.LeftControl))
    //        if (Input.GetKeyDown(KeyCode.A))
    //        {
    //            anim.SetTrigger("SPattack");

    //        }

    //        if (PlayerHP <= 0)//プレーヤーの体力が０以下になると消える
    //        {
    //            anim.SetTrigger("Die");
    //            //StartCoroutine("Defeat");
    //            Destroy(this.gameObject, 1f);//１秒後に消える
    //        }

    //        //    GameObject Enemy = GameObject.Find("Enemy");

    //        //    if (enemyhp.EnemyHP <= 0)
    //        //    {
    //        //        Destroy(Enemy);
    //        //    }

    //        //}

    //        //private IEnumerator Defeat()
    //        //{
    //        //    //1秒待つ
    //        //    yield return new WaitForSeconds(5.0f);
    //        //}

    //    }


    //void OnCollisionEnter2D(Collision2D collision)//当たり判定処理
    //{

    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    Debug.Log("敵が接触！！");
    //    //    PlayerHP -= 2;//2ダメージ
    //    //    Debug.Log(PlayerHP);
    //    //}

    //    //if (collision.gameObject.tag == "stone")
    //    //{
    //    //    Debug.Log("石ゲット");
    //    //    PlayerHP += 5;//5回復
    //    //    Debug.Log(PlayerHP);
    //    //}
    //}


    //    void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            Debug.Log("敵が接触！！");
    //            PlayerHP -= 2;//2ダメージ
    //            Debug.Log(PlayerHP);
    //        }

    //        if (collision.gameObject.tag == "stone")
    //        {
    //            Debug.Log("石ゲット");
    //            PlayerHP += 5;//5回復
    //            Debug.Log(PlayerHP);
    //        }


    //        //if (collision.gameObject.tag == "Trap")
    //        //{
    //        //    Debug.Log("トラップだ！");
    //        //    PlayerHP -= 1;//１ダメージ
    //        //    Debug.Log(PlayerHP);
    //        //}

    //        //if (collision.gameObject.tag == "Goal")
    //        //{
    //        //    SceneManager.LoadScene("Clear");
    //        //}


    //        //if (collision.gameObject.tag == "Enemy" && collision.gameObject.tag == "Attack")
    //        //{
    //        //    Debug.Log("★☆敵に攻撃！！");
    //        //    enemyhp.EnemyHP -= 1;//1ダメージ
    //        //    Debug.Log("<color=red>(・∀・)</color>" + enemyhp.EnemyHP);
    //        //}

    //        //if (collision.gameObject.tag == "EnemyAttack")
    //        //{
    //        //    Debug.Log("敵の攻撃！！");
    //        //    PlayerHP -= 1;//1ダメージ
    //        //    PlayerHP -= (script.EnemyPOWER);//1ダメージ
    //        //    Debug.Log("☆" + PlayerHP);
    //        //}
    //    }

}
