using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logmes : MonoBehaviour
{
    public float PlayerHP2 = 10;

    void Update()
    {
        //使うテキストログ
        //void OnCollisionEnter2D(Collision2D collision)//当たり判定処理
        //{
        //    if (collision.gameObject.tag == "stone")
        //    {
        //        Debug.Log("石ゲット");
        //        PlayerHP2 += 5;//5回復
        //        Debug.Log(PlayerHP2);
        //    }
        //}

        //テキストログ実験用
        //通常色（白）
        if (Input.GetKeyDown(KeyCode.Z))
            print("Zを押しました");

        ////通常色（白）
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //    Debug.Log("横に入力されました");

        //赤
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //Debug.Log("<color=red>横に入力されました</color>");

        //    //青
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=Blue>横に入力されました</color>");

        //    //緑
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=green>横に入力されました</color>");

        //    //黄色
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=yellow>横に入力されました</color>");
    }
}