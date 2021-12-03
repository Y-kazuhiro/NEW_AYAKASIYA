using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //シーン遷移に必要な記述

public class GameOver : MonoBehaviour
{
    private GameObject[] PlayerObjects;  //GameObjectにPlayerObjectsを格納します

    void Update()
    {
        //消えるオブジェクトにBlockタグをつけます。
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player");

        if (PlayerObjects.Length == 0)  //Playerタグがついてる残りが0になれば
        {
            SceneManager.LoadScene("Gameover");  //クリアシーンを表示
        }
    }
}