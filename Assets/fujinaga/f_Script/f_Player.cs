using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class Player : MovingObject
//{
//    public SpriteRenderer Spr; // 表示スプライト
//    public Animator anm; // アニメーションコンポーネント
//    public GameObject GameManager;
//    public GameState PlayerState;
//    public GameObject HitEffect;
//    public GameObject DeathEffect;

//    //ここからステータス
//    [System.NonSerialized] public int Hp = 100; //HP
//    [System.NonSerialized] public int Atk = 30; //攻撃力
//    [System.NonSerialized] public int Def = 25; //防御力

//    //ここまでステータス

//    void Update()
//    {
//        int horizontal = 0; //水平方向
//        int vertical = 0; //垂直方向
//        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
//        vertical = (int)(Input.GetAxisRaw("Vertical"));

//        if (horizontal != 0 || vertical != 0)
//        {
//            AttemptMove(horizontal, vertical);
//        }

//    }

//    //継承クラスMovingObjectのプレイヤー移動処理を実行
//    protected override void AttemptMove(int Xdir, int Ydir)
//    {
//        GameManager = GameObject.FindGameObjectWithTag("GameManager");
//        PlayerState = GameManager.GetComponent<GameManager>().CurrentGameState;

//        if (PlayerState == GameState.KeyInput)
//        {
//            base.AttemptMove(Xdir, Ydir);
//            GameManager.GetComponent<GameManager>().SetCurrentState(GameState.PlayerTurn);
//        }
//    }

//    //エネミーに与えるダメージを計算して与える
//    protected override void OnCantMove(GameObject hitComponent)
//    {
//        //衝突判定のあったオブジェクトの関数を取得し、変数を代入可能にする
//        Enemy Script = hitComponent.GetComponent<Enemy>();
//        //ダメージ計算
//        int Damage = Atk * Atk / (Atk + Script.Def);
//        //オブジェクトのHP変数にダメージを与える
//        Script.Hp -= Damage;
//        Instantiate(HitEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
//        //HPが0以下になったら敵をDestroyして死亡エフェクトを出すこと
//        if (Script.Hp <= 0)
//        {
//            Destroy(hitComponent);
//            Instantiate(DeathEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
//        }
//        Debug.Log("あなたは" + Damage + "のダメージを与えた");
//        Debug.Log("敵の残りHPは" + Script.Hp);
//    }

//}