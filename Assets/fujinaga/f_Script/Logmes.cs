using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logmes : MonoBehaviour
{
    public float PlayerHP2 = 10;

    void Update()
    {
        //�g���e�L�X�g���O
        //void OnCollisionEnter2D(Collision2D collision)//�����蔻�菈��
        //{
        //    if (collision.gameObject.tag == "stone")
        //    {
        //        Debug.Log("�΃Q�b�g");
        //        PlayerHP2 += 5;//5��
        //        Debug.Log(PlayerHP2);
        //    }
        //}

        //�e�L�X�g���O�����p
        //�ʏ�F�i���j
        if (Input.GetKeyDown(KeyCode.Z))
            print("Z�������܂���");

        ////�ʏ�F�i���j
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //    Debug.Log("���ɓ��͂���܂���");

        //��
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //Debug.Log("<color=red>���ɓ��͂���܂���</color>");

        //    //��
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=Blue>���ɓ��͂���܂���</color>");

        //    //��
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=green>���ɓ��͂���܂���</color>");

        //    //���F
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //        //Debug.Log("<color=yellow>���ɓ��͂���܂���</color>");
    }
}