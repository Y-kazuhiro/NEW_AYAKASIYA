using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移させる場合に必要



public class Player1naka : MonoBehaviour
{
    //プレイヤー情報
    public static float PlayerHP = 50;//HP
    public static float PlayerHPMAX = 50;//HP上限
    public static float PlayerHPSab = 50;//HP保管用
    public static float PlayerPower = 2;//攻撃力
    public static float PlayerPowerSub = 2;//攻撃力保管用
    public static float PlayerSPAttack = 100;//必殺技使用回数
    public static float PlayerSPAttackSub = 10;//必殺技使用回数保管用
    public static bool PlayerSPLock = false;//必殺技ロック
    public static float PlayerEXP = 0;//経験値
    public static float NEXTPoint = 0;//ゴールに必要なポイント数
    public static float GoalCount = 0;
    public static float P_turn = 2;//プレイヤーターン　　２回行動
    public static float Youki = 15;//妖気
    public static double P_turncount = 0;
    public static bool walk = false;//連続移動防止
    public static bool get = false;//連続回復防止
    public static bool Event = false;
    double P = 0.5;
    public bool isDamage = false;
    public SpriteRenderer sp;
    public static float PlayerMUKI = 0;//プレイヤーの向き

    public static double Spell = 4;

    public static bool Playerlevelflag = false;
    public static bool PlayerKAIHUKUflag = false;

    private GameObject[] BossObjects;  //GameObjectにBossObjectsを格納します

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

        Boss = GameObject.Find("Boss"); //Enemy変数共有化
        boss = Boss.GetComponent<Boss>();

        walk = false;
        //--------------------------------------------------------------------
    }

    void Update()
    {
        BossObjects = GameObject.FindGameObjectsWithTag("Boss");

        if (Youki >= 15)
        {
            PlayerSPLock = true;
        }

        if (PlayerHP >= 1 && P_turn != 0)//プライヤーのターンが残っていたら行動できる
        {
            //-----------プレイヤーが移動する　ターン消費あり--------------------
            if (Input.GetKeyDown(KeyCode.UpArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, 1, 0);//上に1マス移動
                anim.SetBool("上", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 1;
                if (P_turn == 0)
                {
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 0.3f);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 0.3f);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                this.transform.Translate(0, -1, 0);//下に1マス移動
                anim.SetBool("下", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 2;
                if (P_turn == 0)
                {
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 0.3f);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 0.3f);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                this.transform.Translate(1, 0, 0);//右に1マス移動
                anim.SetBool("右", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 3;
                if (P_turn == 0)
                {
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 0.3f);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 0.3f);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && walk == false)
            {
                audioSource.PlayOneShot(sound2);
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                this.transform.Translate(-1, 0, 0);//左に1マス移動
                anim.SetBool("左", true);
                P_turn--;
                Spell--;
                PlayerMUKI = 4;
                if (P_turn == 0)
                {
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 0.3f);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 0.3f);
                    }
                }
            }
            //------------------------------------------------------------------

            //------------プレイヤーの方向を変える　ターン消費なし----------------
            if (Input.GetKeyDown(KeyCode.W))//上を向く
            {
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("上", true);
                PlayerMUKI = 1;
            }

            if (Input.GetKeyDown(KeyCode.S))//下を向く
            {
                anim.SetBool("上", false);
                anim.SetBool("右", false);
                anim.SetBool("左", false);
                anim.SetBool("下", true);
                PlayerMUKI = 2;
            }

            if (Input.GetKeyDown(KeyCode.D))//右を向く
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("左", false);
                anim.SetBool("右", true);
                PlayerMUKI = 3;
            }

            if (Input.GetKeyDown(KeyCode.A))//左を向く
            {
                anim.SetBool("上", false);
                anim.SetBool("下", false);
                anim.SetBool("右", false);
                anim.SetBool("左", true);
                PlayerMUKI = 4;
            }

            //----------------------------------------------------------------
            //攻撃
            if (Input.GetKeyDown(KeyCode.Space) && walk == false)//スペースで攻撃
            {
                anim.SetTrigger("PlayerAttack");
                audioSource.PlayOneShot(sound4);
                P_turn--;
                Spell--;
                walk = true;

                if (SceneManager.GetActiveScene().name == "Last")
                {
                    if (BossObjects.Length == 0)
                    {
                        Invoke("Walk", 0f);
                    }
                    else
                    {
                        if (Spell == 2)
                        {
                            Invoke("Walk", 1);
                        }
                        else
                        {
                            Invoke("Walk", 3f);
                        }
                    }
                }
                else
                {
                    Invoke("Walk", 1f);
                }
            }



            if (Input.GetKeyDown(KeyCode.Q) && walk == false)//範囲必殺技
            {

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>解放されていない</color>");
                    Debug.Log("<color=red>解放に必要な妖気</color>" + Youki + "/15");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPattack();
                    P_turn--;
                    Spell--;
                    Debug.Log("必殺技残り" + PlayerSPAttack + "回");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }
                else if (PlayerSPAttack <= 0)
                {
                    Debug.Log("<color=red>技が出せない！</color>");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && walk == false)//横必殺技
            {

                if (PlayerSPLock == false)
                {
                    Debug.Log("<color=red>解放されていない</color>");
                    Debug.Log("<color=red>解放に必要な妖気</color>" + Youki + "/15");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }

                if (PlayerSPAttack >= 1 && PlayerSPLock == true)
                {
                    SPSPattack();
                    P_turn--;
                    Spell--;
                    Debug.Log("必殺技残り" + PlayerSPAttack + "回"); ;
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }
                else if (PlayerSPAttack <= 0)
                {
                    Debug.Log("<color=red>技が出せない！</color>");
                    Debug.Log("-----------------------------------------------------");
                    walk = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (BossObjects.Length == 0)
                        {
                            Invoke("Walk", 0f);
                        }
                        else
                        {
                            if (Spell == 2)
                            {
                                Invoke("Walk", 1);
                            }
                            else
                            {
                                Invoke("Walk", 3f);
                            }
                        }
                    }
                    else
                    {
                        Invoke("Walk", 1f);
                    }
                }
            }
        }

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (PlayerEXP >= 100 && PlayerHP >= 1)//レベルアップ
        {
            audioSource.PlayOneShot(sound7);

            PlayerHPMAX += 10;
            PlayerHP = PlayerHPMAX;
            PlayerPower += 2;
            PlayerSPAttack += 2;
            PlayerKAIHUKUflag = true;
            Playerlevelflag = true;

            Debug.Log("<color=blue>★レベルアップ！</color>");
            Debug.Log("体力最大値 + 10");
            Debug.Log("攻撃力 + 2");
            Debug.Log("必殺技回数 + 2");
            Debug.Log("-----------------------------------------------------");

            PlayerEXP = 0;
        }

        if (PlayerHP <= 0 && get == false)//プレーヤーの体力が０以下になるとゲームオーバー
        {
            get = true;
            walk = true;
            P_turn = 0;

            audioSource.PlayOneShot(sound6);

            anim.SetTrigger("Die");
            Invoke("Die",3);
        }

        StartCoroutine("TurnReset");

    }

    //シーン移行と同時にステータスを初期化
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
        get = false;
        Event = false;
        walk = false;
        //SceneManager.LoadScene("GameOver");
        FadeManager.Instance.LoadScene("GameOver", 1.0f);
    }

    void Walk()
    {
        walk = false;
    }


    void Get()
    {
        get = false;
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

    void Damage()
    {
        isDamage = true;
    }

    IEnumerator TurnReset()//ターンリセットする
    {
        if (P_turn == 0)
        {
            yield return null;
            P_turn = 2;//ターン回復
            P_turncount += P;
        }

        if (Spell == 0)
        {
            yield return null;
            Spell = 4;
        }
    }

    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35秒点滅する
                                               // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }

    //----------------------------------------//当たり判定処理---------------------------
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(sound1);
            enemy.EnemyHP -= PlayerPower;//Enemyに攻撃

            if(enemy.EnemyHP < 0)
            {
                enemy.EnemyHP -= enemy.EnemyHP;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemy.EnemyHP);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "Enemy3")
        {
            audioSource.PlayOneShot(sound1);
            enemy3.EnemyHP3 -= PlayerPower;//Enemy3に攻撃

            if (enemy3.EnemyHP3 < 0)
            {
                enemy3.EnemyHP3 -= enemy3.EnemyHP3;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemy3.EnemyHP3);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "EGhost")
        {
            audioSource.PlayOneShot(sound1);
            enemyG.EnemyHPG -= PlayerPower;//EGhostに攻撃

            if (enemyG.EnemyHPG < 0)
            {
                enemyG.EnemyHPG -= enemyG.EnemyHPG;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyG.EnemyHPG);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "LEnemy")
        {
            audioSource.PlayOneShot(sound1);
            enemyL.EnemyHPL -= PlayerPower;//LEnemyに攻撃

            if (enemyL.EnemyHPL < 0)
            {
                enemyL.EnemyHPL -= enemyL.EnemyHPL;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyL.EnemyHPL);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "EDarkGhost")
        {
            audioSource.PlayOneShot(sound1);
            enemyDarkG.EnemyHPDG -= PlayerPower;

            if (enemyDarkG.EnemyHPDG < 0)
            {
                enemyDarkG.EnemyHPDG -= enemyDarkG.EnemyHPDG;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyDarkG.EnemyHPDG);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "EKnight")
        {
            audioSource.PlayOneShot(sound1);
            enemyKnight.EnemyHPK -= PlayerPower;

            if (enemyKnight.EnemyHPK < 0)
            {
                enemyKnight.EnemyHPK -= enemyKnight.EnemyHPK;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyKnight.EnemyHPK);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "EGoblin")
        {
            audioSource.PlayOneShot(sound1);
            enemyGoblin.EnemyHPGob -= PlayerPower;

            if (enemyGoblin.EnemyHPGob < 0)
            {
                enemyGoblin.EnemyHPGob -= enemyGoblin.EnemyHPGob;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyGoblin.EnemyHPGob);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "EGoblin1")
        {
            audioSource.PlayOneShot(sound1);
            enemyGoblin1.EnemyHPGob1 -= PlayerPower;

            if (enemyGoblin1.EnemyHPGob1 < 0)
            {
                enemyGoblin1.EnemyHPGob1 -= enemyGoblin1.EnemyHPGob1;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyGoblin1.EnemyHPGob1);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "ETree")
        {
            audioSource.PlayOneShot(sound1);
            enemyTree.EnemyHPT -= PlayerPower;

            if (enemyTree.EnemyHPT < 0)
            {
                enemyTree.EnemyHPT -= enemyTree.EnemyHPT;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + enemyTree.EnemyHPT);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "Boss")
        {
            audioSource.PlayOneShot(sound1);
            boss.BossHP -= PlayerPower;

            if (boss.BossHP < 0)
            {
                boss.BossHP -= boss.BossHP;
            }

            Debug.Log("<color=blue>★</color>" + PlayerPower + "のダメージを与えた");
            Debug.Log("<color=red>★</color>" + "敵HP" + boss.BossHP);
            Debug.Log("-----------------------------------------------------");
            Invoke("Damage", 0.5f);
        }

        if (collision.gameObject.tag == "stone" && get == false)//石取得
        {
            audioSource.PlayOneShot(sound5);
            float stone = 10;
            float SPstone = 1;

            if (PlayerHP + stone >= PlayerHPMAX)
            {
                get = true;
                PlayerHP += PlayerHPMAX - PlayerHP;
                Debug.Log("<color=blue>★</color>" + "HP" + stone + "回復");
                //Debug.Log("<color=blue>★</color>" + "HP" + PlayerHP);
                PlayerSPAttack += SPstone;
                Debug.Log("<color=blue>★</color>" + "必殺技回数+" + SPstone);
                Debug.Log("<color=blue>★</color>" + "必殺技あと" + PlayerSPAttack + "回");
                Debug.Log("-----------------------------------------------------");
                PlayerKAIHUKUflag = true;
                Invoke("Get", 1);
            }
            else
            {
                get = true;
                PlayerHP += stone;//10回復
                Debug.Log("<color=blue>★</color>" + "HP" + stone + "回復");
                //Debug.Log("<color=blue>★</color>" + "HP" + PlayerHP);
                PlayerSPAttack += SPstone;
                Debug.Log("<color=blue>★</color>" + "必殺技回数+" + SPstone);
                Debug.Log("<color=blue>★</color>" + "必殺技あと" + PlayerSPAttack + "回");
                Debug.Log("-----------------------------------------------------");
                PlayerKAIHUKUflag = true;
                Invoke("Get", 1);
            }


        }
        //----------------------------------シーン切り替え----------------------------------------------
        if (collision.gameObject.tag == "Goal2")//第2ステージに進む
        {
            if (NEXTPoint >= NEXTCOUNT1)
            {
                //SceneManager.LoadScene("Nakano3");
                FadeManager.Instance.LoadScene("Nakano3", 1.0f);
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT1);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal3")//第３ステージに進む
        {
            if (NEXTPoint >= NEXTCOUNT2)
            {
                //SceneManager.LoadScene("Nakano");
                FadeManager.Instance.LoadScene("Nakano", 1.0f);
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT2);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal")
        {
            if (NEXTPoint >= NEXTCOUNT3)
            {
                //SceneManager.LoadScene("Nakano1");//第４ステージに進む
                FadeManager.Instance.LoadScene("Nakano1", 1.0f);
                GoalCount++;
                walk = false;
            }
            else
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT3);
            Debug.Log("-----------------------------------------------------");
        }

        if (collision.gameObject.tag == "Goal1")
        {
            if (NEXTPoint >= NEXTCOUNT4)
            {
                //SceneManager.LoadScene("Last");//ラスステ
                FadeManager.Instance.LoadScene("Last", 1.0f);
                GoalCount++;
                walk = false;
            }
            else
            {
                Debug.Log("<color=red>ポイントが足りない</color>" + NEXTPoint + "/" + NEXTCOUNT4);
                Debug.Log("-----------------------------------------------------");
            }
        }

        if (collision.gameObject.tag == "Goal4")
        {           
            SceneManager.LoadScene("Clear");//クリア
            //FadeManager.Instance.LoadScene("Clear", 1.0f);
            //PlayerHP = PlayerHPSab;
            //PlayerHPMAX = PlayerHPSab;
            //PlayerPower = PlayerPowerSub;
            //PlayerSPAttack = PlayerSPAttackSub;
            //PlayerSPLock = false;
            //GoalCount = 0;
            //PlayerEXP = 0;
            //NEXTPoint = 0;
            //Youki = 0;
            //P_turncount = 0;
            //P_turn = 0;
            //walk = false;
            //Event = false;
            //get = false;
            Invoke("Die",2);
        }

        //最後の会話
        if (collision.gameObject.tag == "event" && Event == false)
        {
            Event = true;
            Debug.Log("よくぞここまで辿り着きました。");
            Debug.Log("この先に妖達の大将がいます");
            Debug.Log("どうか私たちの無念を、");
            Debug.Log("雪辱を晴らしてください。");
            Debug.Log("");
            Debug.Log("ご武運を。");
            Debug.Log("-----------------------------------------------------");
        }
    }

}