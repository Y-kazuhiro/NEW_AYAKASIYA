using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //�V�[���J�ڂɕK�v�ȋL�q

public class GameOver : MonoBehaviour
{
    private GameObject[] PlayerObjects;  //GameObject��PlayerObjects���i�[���܂�

    void Update()
    {
        //������I�u�W�F�N�g��Block�^�O�����܂��B
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player");

        if (PlayerObjects.Length == 0)  //Player�^�O�����Ă�c�肪0�ɂȂ��
        {
            SceneManager.LoadScene("Gameover");  //�N���A�V�[����\��
        }
    }
}