using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移させる場合に必要



public class Player1naka : MonoBehaviour
{
    //プレイヤー情報
    public static float PlayerHP = 50;//HP
    public static float PlayerHPSab = 50;//HP保管用
    public static float PlayerPower = 2;//攻撃力
    public static float PlayerSPAttack = 10;//必殺技使用回数
    public static bool PlayerSPLock = false;//必殺技ロック
    public static float PlayerEXP = 0;//経験値
    public static float NEXTPoint = 0;//ゴールに必要なポイント数
    public static float GoalCount = 0;
    public float P_turn = 2;//プレイヤーターン　　２回行動
    public static float Youki = 0;//妖気


    //------------ゴールに必要なポイント----------
    public static float NEXTCOUNT1 = 5;
    public static float NEXTCOUNT2 = 15;
    public static float NEXTCOUNT3 = 25;
    public static float NEXTCOUNT4 = 35;
    //--------------------------------------------



    //敵の情報を取得する--------------------------------------------
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
    //------------------------------------------------------------

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

        //敵の情報を取得する-------------------------------------------------
        Enemy1 = GameObject.Find("Enemy1"); //Enemy変数共有化
        enemy = Enemy1.GetComponent<Enemy1>();

        Enemy3 = GameObject.Find("Enemy3"); //Enemy変数共有化
        enemy3 = Enemy3.GetComponent<Enemy3>();

        EGhost = GameObject.Find("EGhost"); //Enemy変数共有化
        enemyG = EGhost.GetComponent<EGhost>();

        EDarkGhost = GameObject.Find("EDarkGhost"); //Enemy変数共有化
        enemyDarkG = EDarkGhost.GetComponent<EDarkGhost>();

        LEnemy = GameObject.Find("LEnemy"); //Enemy変数共有化
        enemyL = LEnemy.GetComponent<LEnemy>();

        EKnight = GameObject.Find("EKnight"); //Enemy変数共有化
        enemyKnight = EKnight.GetComponent<EKnight>();

        EGoblin = GameObject.Find("EGoblin"); //Enemy変数共有化
        enemyGoblin = EGoblin.GetComponent<EGoblin>();

        EGoblin1 = GameObject.Find("EGoblin1"); //Enemy変数共有化
        enemyGoblin1 = EGoblin1.GetComponent<EGoblin1>();

        ETree = GameObject.Find("ETree"); //Enemy変数共有化
        enemyTree = ETree.GetComponent<ETree>();
        //--------------------------------------------------------------------
    }

    void Update()
    {

        if (P_turn != 0)//プライヤーのターンが残っていたら行動できる
        {
            //-----------プレイヤーが移動する　ターン消費あり--------------------
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, 1, 0);//上に1マス移動
                anim.SetBool("上", true);
                P_turn--;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, -1, 0);//下に1マス移動
                anim.SetBool("下", true);
                P_turn--;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audioSource.PlayOneShot(sound2);



                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                this.transform.Translate(1, 0, 0);//右に1マス移動
                anim.SetBool("右", true);
                P_turn--;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                this.transform.Translate(-1, 0, 0);//左に1マス移動
                anim.SetBool("左", true);
                P_turn--;
            }

            //------------------------------------------------------------------

            //------------プレイヤーの方向を変える　ターン消費なし----------------
            if (Input.GetKeyDown(KeyCode.W))//上を向く
            {
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("上", true);
            }

            if (Input.GetKeyDown(KeyCode.S))//下を向く
            {
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("下", true);
            }

            if (Input.GetKeyDown(KeyCode.D))//右を向く
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                anim.SetBool("右", true);
            }

            if (Input.GetKeyDown(KeyCode.A))//左を向く
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
                if (Youki >= 15)
                {
                    PlayerSPLock = true;
                }

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>解放されていない</color>");
                    Debug.Log("<color=red>解放に必要な妖気</color>" + Youki + "/15");
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPattack();
                    P_turn--;
                    Debug.Log("必殺技あと" + PlayerSPAttack + "回");
                }
                else if (PlayerSPAttack <= 0)
                    Debug.Log("<color=red>技が出せない！</color>");
            }

            if (Input.GetKeyDown(KeyCode.E))//横必殺技
            {
                if (Youki >= 15)
                {
                    PlayerSPLock = true;
                }

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>解放されていない</color>");
                    Debug.Log("<color=red>解放に必要な妖気</color>" + Youki + "/15");
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPSPattack();
                    P_turn--;
                    Debug.Log("必殺技あと" + PlayerSPAttack + "回"); ;
                }
                else if (PlayerSPAttack <= 0)
                    Debug.Log("<color=red>技が出せない！</color>");
            }
        }

        if(PlayerEXP>=100)//レベルアップ
        {
            PlayerHP += 5;
         PlayerPower += 2;
         PlayerSPAttack += 2;

            Debug.Log("<color=blue>★レベルアップ！</color>");
            Debug.Log("体力を 15 回復");
            Debug.Log("攻撃力が 2 アップ");
            Debug.Log("必殺技回数 + 2");

            PlayerEXP = 0;
        }

        if (PlayerHP <= 0)//プレーヤーの体力が０以下になるとゲームオーバー
        {
            anim.SetTrigger("Die");
            SceneManager.LoadScene("GameOver");
            PlayerHP = PlayerHPSab;
        }

        StartCoroutine("TurnReset");
    }

    IEnumerator TurnReset()//ターンリセットする
    {
        if (P_turn == 0)
        {
            yield return null;
            P_turn = 2;//ターン回復
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

    //----------------------------------------//当たり判定処理---------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.EnemyHP -= PlayerPower;//Enemyに攻撃
            Debug.Log("<color=red>★</color>" + "敵HP" + enemy.EnemyHP);
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            enemy3.EnemyHP3 -= PlayerPower;//Enemy3に攻撃
            Debug.Log("<color=red>★</color>" + "敵HP" + enemy3.EnemyHP3);
        }

        if (collision.gameObject.tag == "EGhost")
        {
            enemyG.EnemyHPG -= PlayerPower;//EGhostに攻撃
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyG.EnemyHPG);
        }

        if (collision.gameObject.tag == "LEnemy")
        {
            enemyL.EnemyHPL -= PlayerPower;//LEnemyに攻撃
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyL.EnemyHPL);
        }

        if (collision.gameObject.tag == "EDarkGhost")
        {
            enemyDarkG.EnemyHPDG -= PlayerPower;
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyDarkG.EnemyHPDG);
        }

        if (collision.gameObject.tag == "EKnight")
        {
            enemyKnight.EnemyHPK -= PlayerPower;
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyKnight.EnemyHPK);
        }

        if (collision.gameObject.tag == "EGoblin")
        {
            enemyGoblin.EnemyHPGob -= PlayerPower;
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyGoblin.EnemyHPGob);
        }

        if (collision.gameObject.tag == "EGoblin1")
        {
            enemyGoblin1.EnemyHPGob1 -= PlayerPower;
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyGoblin1.EnemyHPGob1);
        }

        if (collision.gameObject.tag == "ETree")
        {
            enemyTree.EnemyHPT -= PlayerPower;
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyTree.EnemyHPT);
        }

        if (collision.gameObject.tag == "stone")//石取得
        {
            float stone = 15;
            float SPstone = 2;
            PlayerHP += stone;//10回復
            Debug.Log("<color=blue>★</color>" + "HP+" + stone);
            Debug.Log("<color=blue>★</color>" + "HP" + PlayerHP);
            PlayerSPAttack += SPstone;
            Debug.Log("<color=blue>★</color>" + "必殺技回数+" + SPstone);
            Debug.Log("<color=blue>★</color>" + "必殺技あと" + PlayerSPAttack + "回");
        }
        //---------------------------------------------------------------------------------------------
        //----------------------------------シーン切り替え----------------------------------------------
        if (collision.gameObject.tag == "Goal2")//第2ステージに進む
        {
            if (NEXTPoint >= NEXTCOUNT1)
            {
                SceneManager.LoadScene("Nakano3");
                GoalCount++;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT1);
        }

        if (collision.gameObject.tag == "Goal3")//第３ステージに進む
        {
            if (NEXTPoint >= NEXTCOUNT2)
            {
                SceneManager.LoadScene("Nakano");
                GoalCount++;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT2);
        }

        if (collision.gameObject.tag == "Goal")
        {
            if (NEXTPoint >= NEXTCOUNT3)
            {
                SceneManager.LoadScene("Nakano1");//第４ステージに進む
                GoalCount++;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT3);
        }

        if (collision.gameObject.tag == "Goal1")
        {
            if (NEXTPoint >= NEXTCOUNT4)
            {
                SceneManager.LoadScene("Clear");//ゴール
                GoalCount++;
                PlayerHP = PlayerHPSab;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT4);
        }
        //-------------------------------------------------------------------------------------------
    }
}