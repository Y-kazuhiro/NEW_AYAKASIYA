using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunTextC1 : MonoBehaviour
{

    public GameObject Trun_object = null;
    

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W�ʂ̃|�C���g�\������
        //������������������
        
        //��1�X�e�[�W
        //if ()
        //{
            Text Trun_text = Trun_object.GetComponent<Text>();

�@�@�@�@�@�@//���̃X�e�[�W�֍s���|�C���g�����\��
            //���܂�Ǝ��̃X�e�[�W�ɍs����悤�ɂȂ�(��2�X�e�[�W��)
            Trun_text.text = "<color=red>���̃X�e�[�W�܂�</color> "
            + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1;//�ԐF
        //}

        //��2�X�e�[�W
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //���̃X�e�[�W�֍s���|�C���g�����\��
        //    //���܂�Ǝ��̃X�e�[�W�ɍs����悤�ɂȂ�(��3�X�e�[�W��)
        //    Trun_text.text = "<color=red>���̃X�e�[�W�܂�</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2;//�ԐF
        //}

        //��3�X�e�[�W
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //���̃X�e�[�W�֍s���|�C���g�����\��
        //    //���܂�Ǝ��̃X�e�[�W�ɍs����悤�ɂȂ�(��4�X�e�[�W��)
        //    Trun_text.text = "<color=red>���̃X�e�[�W�܂�</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3;//�ԐF
        //}

        //��4�X�e�[�W
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //���̃X�e�[�W�֍s���|�C���g�����\��
        //    //���܂�Ǝ��̃X�e�[�W�ɍs����悤�ɂȂ�(���X�g�X�e�[�W��)
        //    Trun_text.text = "<color=red>���̃X�e�[�W�܂�</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4;//�ԐF
        //}
    }
}