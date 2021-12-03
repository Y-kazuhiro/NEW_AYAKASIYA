using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移させる場合に必要

public class Player2naka : MonoBehaviour
{
    //プレイヤー情報
    public float PlayerHP = 50;//HP
    public float PlayerPower = 2;//攻撃力
    public float PlayerSPAttack = 10;//必殺技使用回数

    public float P_turn = 2;//プレイヤーターン　　２回行動


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
        //Enemy1 = GameObject.Find("Enemy1");  //Enemy変数共有化
        //enemy = Enemy1.GetComponent<Enemy1>();

        //Enemy3 = GameObject.Find("Enemy3");  //Enemy変数共有化
        //enemy3 = Enemy3.GetComponent<Enemy3>();

        //EGhost = GameObject.Find("EGhost");  //Enemy変数共有化
        //enemyG = EGhost.GetComponent<EGhost>();

        //LEnemy = GameObject.Find("LEnemy");  //Enemy変数共有化
        //enemyL = LEnemy.GetComponent<LEnemy>();
    }


    void Update()
    {

        if (P_turn != 0)
        {
            //-----------プレイヤーが移動する　ターン消費あり--------------------
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, 1, 0);
                anim.SetBool("上", true);

                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, -1, 0);
                anim.SetBool("下", true);
                P_turn--;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                this.transform.Translate(1, 0, 0);
                anim.SetBool("右", true);
                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                this.transform.Translate(-1, 0, 0);
                anim.SetBool("左", true);
                P_turn--;
            }
            //------------------------------------------------------------------


            //------------プレイヤーの方向を変える　ターン消費なし----------------
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("上", true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("下", true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                anim.SetBool("右", true);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", true);
            }
            //----------------------------------------------------------------


            //攻撃
            if (Input.GetKeyDown(KeyCode.Space))//スペースで攻撃
            {
                anim.SetTrigger("PlayerAttack");
                audioSource.PlayOneShot(sound1);
                P_turn--;
            }
            if (Input.GetKeyDown(KeyCode.Q))//範囲必殺技
            {
                if (PlayerSPAttack >= 0)
                {
                    SPattack();
                    P_turn--;
                    Debug.Log(PlayerSPAttack);
                }
                else
                    Debug.Log("<color=red>技が出せない！</color>");
            }

            if (Input.GetKeyDown(KeyCode.E))//横必殺技
            {
                if (PlayerSPAttack >= 0)
                {
                    SPSPattack();
                    P_turn--;
                    Debug.Log(PlayerSPAttack);
                }
                else
                    Debug.Log("<color=red>技が出せない！</color>");
            }
        }

        if (PlayerHP <= 0)//プレーヤーの体力が０以下になると消える
        {
            anim.SetTrigger("Die");
            //StartCoroutine("Defeat");
            Destroy(this.gameObject, 1f);//１秒後に消える
        }

        StartCoroutine("Defeat");

    }

    IEnumerator Defeat()
    {
        if (P_turn == 0)
        {

            //enemy.E_turn = 2;
            //秒待つ
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

    void OnCollisionEnter2D(Collision2D collision)//当たり判定処理
    {

        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("必殺技！！");
        //    //PlayerHP -= 2;//2ダメージ
        //    //Debug.Log(PlayerHP);
        //}

        //if (collision.gameObject.tag == "stone")
        //{
        //    Debug.Log("石ゲット");
        //    PlayerHP += 5;//5回復
        //    Debug.Log(PlayerHP);
        //}
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.EnemyHP -= PlayerPower;//Enemyに攻撃
            Debug.Log(enemy.EnemyHP);
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            enemy3.EnemyHP3 -= PlayerPower;//Enemyに攻撃
            Debug.Log(enemy3.EnemyHP3);
        }

        if (collision.gameObject.tag == "EGhost")
        {
            enemyG.EnemyHPG -= PlayerPower;//Enemyに攻撃
            Debug.Log(enemyG.EnemyHPG);
        }

        if (collision.gameObject.tag == "LEnemy")
        {
            enemyL.EnemyHPL -= PlayerPower;//Enemyに攻撃
            Debug.Log(enemyL.EnemyHPL);
        }

        if (collision.gameObject.tag == "stone")
        {
            Debug.Log("<color=red>石ゲット</color>");
            PlayerHP += 10;//10回復
            Debug.Log(PlayerHP);
        }



        //if (collision.gameObject.tag == "Trap")
        //{
        //    Debug.Log("トラップだ！");
        //    PlayerHP -= 1;//１ダメージ
        //    Debug.Log(PlayerHP);
        //}

        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Tani1");
        }


        //if (collision.gameObject.tag == "Enemy" && collision.gameObject.tag == "Attack")
        //{
        //    Debug.Log("★☆敵に攻撃！！");
        //    enemyhp.EnemyHP -= 1;//1ダメージ
        //    Debug.Log("<color=red>(・∀・)</color>" + enemyhp.EnemyHP);
        //}

        //if (collision.gameObject.tag == "EnemyAttack")
        //{
        //    Debug.Log("敵の攻撃！！");
        //    PlayerHP -= 1;//1ダメージ
        //    PlayerHP -= (script.EnemyPOWER);//1ダメージ
        //    Debug.Log("☆" + PlayerHP);
        //}
    }



}
