using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunTextC2 : MonoBehaviour
{

    public GameObject Trun_object = null;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Text Trun_text = Trun_object.GetComponent<Text>();
        Trun_text.text = "<color=red>���̃X�e�[�W�܂�</color> "
        + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2;//�ԐF
    }
}